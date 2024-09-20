using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using CsvHelper;
using NLog;

namespace CopilotChatWPF
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(5) };
        private static readonly string apiUrl = "http://static.108.101.245.188.clients.your-server.de:11434/api/generate";
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            txtInput.KeyDown += TxtInput_KeyDown;
            logger.Info("Anwendung gestartet.");
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            await SendMessageAsync();
        }

        private async void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Control)
            {
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            string userInput = txtInput.Text;
            string selectedFunction = (cmbFunctions.SelectedItem as ComboBoxItem)?.Content?.ToString();

            if (selectedFunction != null)
            {
                txtChat.AppendText($"You: {userInput}\n");
                txtInput.Clear();

                // Visuelles Element für die Arbeit des LLM
                txtChat.AppendText("LLM arbeitet...\n");
                txtChat.ScrollToEnd();

                string response = await SendMessageToOllamaAsync(userInput, selectedFunction);
                txtChat.AppendText($"LLM: {response}\n");
                txtChat.ScrollToEnd();

                if (selectedFunction == "Auswertung von Kundenfeedback")
                {
                    var analysis = ParseAnalysisResponse(response);
                    if (analysis != null)
                    {
                        ShowAnalysisResults(analysis);
                        SaveAnalysisOptions(analysis);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Funktion aus.");
            }
        }

        private async Task<string> SendMessageToOllamaAsync(string prompt, string function)
        {
            string fullPrompt = function switch
            {
                "Beantwortung von Mails" => $"Funktion: {function}\nHintergrund: Der Copilot ist für die Mitarbeitenden eines Reiseveranstalters von Ski- und Snowboardreisen nach Österreich und in die Schweiz. Die Zielgruppe sind junge Erwachsene im Alter von 18-30. Es wird grundsätzlich geduzt.\nEingabe: {prompt}\n\nBitte schreibe 3 verschiedene Antwortoptionen (kurze Antwort, mittlere Antwort, lange Antwort) auf die E-Mail, die klar, menschlich und im passenden Sprachstil sind. Die Antworten sollten eine passende Anrede und Schlussformel enthalten.",
                "Erstellung von Social Media Posts" => $"Funktion: {function}\nHintergrund: Der Copilot ist für die Mitarbeitenden eines Reiseveranstalters von Ski- und Snowboardreisen nach Österreich und in die Schweiz. Die Zielgruppe sind junge Erwachsene im Alter von 18-30. Es wird grundsätzlich geduzt.\nEingabe: {prompt}\n\nBitte erstelle einen ansprechenden, lebhaften und relevanten Social Media Post, der die Winter-Sport-Reiseangebote von E&P Reisen fördert.",
                "Erstellung von Blogbeiträgen" => $"Funktion: {function}\nHintergrund: Der Copilot ist für die Mitarbeitenden eines Reiseveranstalters von Ski- und Snowboardreisen nach Österreich und in die Schweiz. Die Zielgruppe sind junge Erwachsene im Alter von 18-30. Es wird grundsätzlich geduzt.\nEingabe: {prompt}\n\nBitte erstelle einen ansprechenden, lebhaften und relevanten Blogartikel, der die Winter-Sport-Reiseangebote von E&P Reisen fördert.",
                "Auswertung von Kundenfeedback" => $"Funktion: {function}\nHintergrund: Der Copilot ist für die Mitarbeitenden eines Reiseveranstalters von Ski- und Snowboardreisen nach Österreich und in die Schweiz. Die Zielgruppe sind junge Erwachsene im Alter von 18-30. Es wird grundsätzlich geduzt.\nEingabe: {prompt}\n\nAnalysiere den folgenden Text und identifiziere die Aspekte, die erwähnt werden. Ordne jeden Aspekt einem der folgenden Themen zu: Unterkunft, Verpflegung, Transport, Skikurs, Skiverleih, Personal, Skipass, Ausstattung, Preis-Leistung, Organisation, Abendprogramm, Sauberkeit, Umgebung, Freizeitmöglichkeiten. Gruppiere die Aspekte nach Sentiment (positiv, neutral, negativ).\n\nAntworte ausschließlich im folgenden JSON-Format, ohne zusätzliche Kommentare oder Text:\n{{\n    \"positiv\": [\n        {{\"Thema\": \"Thema1\", \"Aspekt\": \"Aspekt1\"}},\n        {{\"Thema\": \"Thema2\", \"Aspekt\": \"Aspekt2\"}}\n    ],\n    \"neutral\": [\n        {{\"Thema\": \"Thema3\", \"Aspekt\": \"Aspekt3\"}}\n    ],\n    \"negativ\": [\n        {{\"Thema\": \"Thema4\", \"Aspekt\": \"Aspekt4\"}},\n        {{\"Thema\": \"Thema5\", \"Aspekt\": \"Aspekt5\"}}\n    ]\n}}",
                _ => $"Funktion: {function}\nHintergrund: Der Copilot ist für die Mitarbeitenden eines Reiseveranstalters von Ski- und Snowboardreisen nach Österreich und in die Schweiz. Die Zielgruppe sind junge Erwachsene im Alter von 18-30. Es wird grundsätzlich geduzt.\nEingabe: {prompt}"
            };

            var requestData = new
            {
                model = "llama3.1",
                prompt = fullPrompt,
                stream = false
            };

            string json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                dynamic responseData = JsonConvert.DeserializeObject(responseJson);
                return responseData.response;
            }
            else
            {
                logger.Error($"Fehler beim Senden der Anfrage: {response.StatusCode} - {response.ReasonPhrase}");
                return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
        }

        private Dictionary<string, List<Dictionary<string, string>>> ParseAnalysisResponse(string response)
        {
            try
            {
                int jsonStart = response.IndexOf('{');
                int jsonEnd = response.LastIndexOf('}') + 1;
                string jsonContent = response.Substring(jsonStart, jsonEnd - jsonStart);
                return JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(jsonContent);
            }
            catch (Exception ex)
            {
                logger.Error($"Fehler beim Parsen der Antwort: {ex.Message}");
                MessageBox.Show($"Fehler beim Parsen der Antwort: {ex.Message}");
                return null;
            }
        }

        private void ShowAnalysisResults(Dictionary<string, List<Dictionary<string, string>>> analysis)
        {
            txtChat.AppendText("\n--- Analyseergebnisse ---\n");
            foreach (var sentiment in new[] { "positiv", "neutral", "negativ" })
            {
                var aspects = analysis.GetValueOrDefault(sentiment, new List<Dictionary<string, string>>());
                if (aspects.Count > 0)
                {
                    txtChat.AppendText($"{char.ToUpper(sentiment[0]) + sentiment.Substring(1)}:\n");
                    foreach (var item in aspects)
                    {
                        string thema = item.GetValueOrDefault("Thema", "Unbekanntes Thema");
                        string aspekt = item.GetValueOrDefault("Aspekt", "Unbekannter Aspekt");
                        txtChat.AppendText($"- Thema: {thema}, Aspekt: {aspekt}\n");
                    }
                }
            }
            txtChat.AppendText("\n-------------------------\n");
        }

        private void SaveAnalysisOptions(Dictionary<string, List<Dictionary<string, string>>> analysis)
        {
            var saveOptionsWindow = new SaveOptionsWindow();
            saveOptionsWindow.ShowDialog();

            if (saveOptionsWindow.SelectedOption == "JSON")
            {
                SaveAnalysisJson(analysis);
            }
            else if (saveOptionsWindow.SelectedOption == "CSV")
            {
                SaveAnalysisCsv(analysis);
            }
            else if (saveOptionsWindow.SelectedOption == "Beide")
            {
                SaveAnalysisJson(analysis);
                SaveAnalysisCsv(analysis);
            }
        }

        private void SaveAnalysisJson(Dictionary<string, List<Dictionary<string, string>>> analysis)
        {
            string filename = "analyse_ergebnis.json";
            try
            {
                File.WriteAllText(filename, JsonConvert.SerializeObject(analysis, Formatting.Indented));
                MessageBox.Show($"Analyseergebnis wurde in '{filename}' gespeichert.");
            }
            catch (Exception ex)
            {
                logger.Error($"Fehler beim Speichern der Datei: {ex.Message}");
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}");
            }
        }

        private void SaveAnalysisCsv(Dictionary<string, List<Dictionary<string, string>>> analysis)
        {
            string filename = "analyse_ergebnis.csv";
            try
            {
                using (var writer = new StreamWriter(filename))
                using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.WriteField("Sentiment");
                    csv.WriteField("Thema");
                    csv.WriteField("Aspekt");
                    csv.NextRecord();

                    foreach (var sentiment in new[] { "positiv", "neutral", "negativ" })
                    {
                        var aspects = analysis.GetValueOrDefault(sentiment, new List<Dictionary<string, string>>());
                        foreach (var item in aspects)
                        {
                            csv.WriteField(sentiment);
                            csv.WriteField(item.GetValueOrDefault("Thema", "Unbekanntes Thema"));
                            csv.WriteField(item.GetValueOrDefault("Aspekt", "Unbekannter Aspekt"));
                            csv.NextRecord();
                        }
                    }
                }
                MessageBox.Show($"Analyseergebnis wurde in '{filename}' gespeichert.");
            }
            catch (Exception ex)
            {
                logger.Error($"Fehler beim Speichern der Datei: {ex.Message}");
                MessageBox.Show($"Fehler beim Speichern der Datei: {ex.Message}");
            }
        }
    }
}