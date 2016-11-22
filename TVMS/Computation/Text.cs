using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TVMS.Computation;
using Word = Microsoft.Office.Interop.Word;

namespace TVMS.Computation
{
    class Text
    {
        private string GetTemplate()
        {
            var webClient = new WebClient();
            var link = new Uri(@"https://psv4.vk.me/c810537/u115256989/docs/3f08ab7301b0/template.docx");
            string path = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\template.docx";
            webClient.DownloadFileAsync(link, path);
            return path;
        }

        public Text(string group, string name, string teacher, string year, int n, double alpha, double[] x, double[] y)
        {
            string imagePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\chart.png";
            string chartPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\population.crtx";
            string documentPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Курсовая работа (" + name + ").docx";

            var computation = new Calculation(x, y, alpha);
            var k = (n - 2).ToString();
            var expectationX = computation.ExpectationX;
            var expectationY = computation.ExpectationY;
            var varianceX = computation.VarianceX;
            var varianceY = computation.VarianceY;
            var sigmaX = computation.SigmaX;
            var sigmaY = computation.SigmaY;
            var covariation = computation.Covariation;
            var correlation = computation.Correlation;
            var tDelta = computation.Delta;
            var yieldPoint = computation.YieldPoint;
            var koef = computation.Koefficients;
            

            int[] correlationIndexes = 
            {
                computation.Correlation >=0 ? 1 : 0,
                computation.Correlation > 0 ?
                    computation.Correlation*10 > 5.0 ? 2 : 4 :
                    Math.Abs(computation.Correlation)*10 > 5.0 ? 3 : 4

            };

            var wordApp = new Word.Application {Visible = false};
            var path = GetTemplate();
            //Создаем объект для управления документом
            //В качестве параметра указываем метод, создающий шаблон
            //и возвращающий путь на него.
            try
            {
                var document = wordApp.Documents.Open(path);
                var range = document.Content;

                for (int i = 220; i < document.Sentences.Count; i++)
                {
                    if (document.Sentences[i].Text != "{Image};\r") continue;
                    object startImageLocation = document.Sentences[i].Start;
                    object endImageLocation = document.Sentences[i].End;
                    range = document.Range(ref startImageLocation, ref endImageLocation);
                    break;
                }
                
                for (int i = 0; i < x.Length; i++)
                {
                    Replace(@"{x" + (i + 1) + "}", document, x[i].ToString());
                    Replace(@"{y" + (i + 1) + "}", document, y[i].ToString());
                }
                

                Replace("{CorrelationStubFirst}", document, CorrelationText[correlationIndexes[0]]);
                Replace("{CorrelationStubSecond}", document, CorrelationText[correlationIndexes[1]]);
                Replace("{operator}", document, koef[1] < 0 ? "" : "+");
                Replace("{name}", document, name);
                Replace("{group}", document, group);
                Replace("{teacher}", document, teacher);
                Replace("{year}", document, year);
                Replace("{expectationX}", document, $"{expectationX:0.##}");
                Replace("{expectationY}", document, $"{expectationY:0.##}");
                Replace("{varianceX}", document, $"{varianceX:0.##}");
                Replace("{varianceY}", document, $"{varianceY:0.##}");
                Replace("{sigmaX}", document, $"{sigmaX:0.##}");
                Replace("{sigmaY}", document, $"{sigmaY:0.##}");
                Replace("{k}", document, $"{k}");
                Replace("{covariation}", document, $"{covariation}");
                Replace("{correlation}", document, $"{correlation}");
                document.InlineShapes.AddPicture(imagePath, false, true, range);
                Replace("{Image};", document);
                Replace("{tDelta}", document, $"{tDelta:0.##}");
                Replace("{yieldPoint}", document, $"{yieldPoint:0.##}");
                for (int i = 0; i < 2; i++)
                {
                    Replace("{koeffA}", document, koef[0].ToString());
                    Replace("{koeffB}", document, koef[1].ToString());
                    Replace("{n}", document, $"{x.Length}");
                    Replace("{alpha}", document, $"{alpha:0.00#}");
                }
                string lim = correlationIndexes[0] == 1
                    ? correlationIndexes[1] == 2 ? "1" : "0"
                    : correlationIndexes[1] == 3 ? "-1" : "0";
                bool nullTest = Math.Abs(tDelta) > yieldPoint;
                Replace("{operand}", document, nullTest ? ">" : "≤");
                Replace("{nullConclusion}", document, nullTest ? 
                    "мы отвергаем нулевую гипотезу и говорим, что X и Y коррелированы, то есть связаны линейной зависимостью." :
                    "у нас нет оснований опровергнуть нулевую гипотезу.");
                Replace("{lim}", document, lim);
                Replace("{yesOrNot}", document, lim == "-1" || lim == "1" ? "" : "не");
                

                document.SaveAs(documentPath);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                wordApp.Quit();
            }
            //Удаляем шаблоны
            File.Delete(imagePath);
            File.Delete(chartPath);
            File.Delete(path);
        }

        /// <summary>
        /// Вставка текста в документ
        /// </summary>
        /// <param name="stub">
        /// Что менять
        /// </param>
        /// <param name="text">
        /// Чем заменить
        /// </param>
        /// <param name="document">
        /// В чем менять
        /// </param>
        public void Replace(string stub, Word.Document document, string text = "")
        {
            //Содержимое документа
            var replaceRange = document.Content;
            //Очищаем предыдущий поиск
            replaceRange.Find.ClearFormatting();
            //Выполняем замену
            replaceRange.Find.Execute(stub, ReplaceWith: text);
        }

        public string[] CorrelationText { get; } = {
            "Полученное значение коэффициента корреляции характеризует обратную связь между исследуемыми величинами, так как значение отрицательно.",
            "Полученное значение коэффициента корреляции характеризует прямую связь между исследуемыми величинами, так как значение положительно.",
            "принимает значение близкое к 1, то X и Y связаны линейной функциональной зависимостью.",
            "принимает значение близкое к -1, то X и Y связаны линейной функциональной зависимостью.",
            "принимает значение близкое к 0, то X и Y слабо зависимы.",

        };

        public string[] TDelta { get; } = {
            "не", //0
            "", //1
            ">", //2
            "<", //3
            "X и Y коррелированны, то есть связаны линейной зависимостью", //4
            "связи между X и Y практически не прослеживается." //5
        };
    }
}