using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Color_Picker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> perlerColors = new List<string> { "000000", "797979", "acacac", "d2d2d2", "ffffff", "5d151b", "604737", "7e5034", "d39e69", "f9caa8", "f8fad2", "bf1626", "e30b14", "e41b58", "e4aacd", "fc9f91", "fbbeac", "98114c", "33286c", "452589", "9960a5", "9e7dba", "c3b2d6", "f26526", "ef8d0f", "f7b14d", "ffc730", "f4d949", "f4f7ab", "1e2e29", "067e5a", "098b3b", "2aa36a", "8ec140", "aad590", "4aafca", "0ab2dd", "0ab4aa", "6ac8d4", "a5d1ae", "98d6ea", "1d3d8d", "1b7cbd", "2293d1", "89bde9", "33b9f2", "6bc8f4" };

        List<OnlineBeadColor> artkalColors = new List<OnlineBeadColor>();
        List<OnlineBeadColor> perlerMidiColors = new List<OnlineBeadColor>();
        List<OnlineBeadColor> artkalMidiColors = new List<OnlineBeadColor>();
        List<string> ownedColors = new List<string>();

        private void findColorButton_Click(object sender, EventArgs e)
        {
            string color = textBox1.Text;
            OnlineBeadColor colorByName;

            if (ValidColorString(color))
            {
                exactColor.BackColor = GetColor(color);
                exactColorCode.Text = color;

                if(ArtkalMiniCheckBox.Checked)
                {
                    CompareToArtkalMinis(color);
                }
                else if(perlerMidiCheckBox.Checked)
                {
                    CompareToPerlerMidis(color);
                }
                else if(artkalMidiCheckBox.Checked)
                {
                    CompareToArtkalMidis(color);
                }
                else
                {
                    CompareToCollection(color);
                }
            }
            else if((colorByName = GetColorByName(color)) != null)
            {
                color = colorByName.hex;

                exactColor.BackColor = GetColor(color);
                exactColorCode.Text = color;

                if (ArtkalMiniCheckBox.Checked)
                {
                    CompareToArtkalMinis(color);
                }
                else if (perlerMidiCheckBox.Checked)
                {
                    CompareToPerlerMidis(color);
                }
                else if (artkalMidiCheckBox.Checked)
                {
                    CompareToArtkalMidis(color);
                }
                else
                {
                    CompareToCollection(color);
                }
            }
        }

        private OnlineBeadColor GetColorByName(string color)
        {
            List<OnlineBeadColor> allColors = new List<OnlineBeadColor>();

            allColors.AddRange(artkalMidiColors);
            allColors.AddRange(artkalColors);
            allColors.AddRange(perlerMidiColors);

            for(int i = 0; i < allColors.Count;i++)
            {
                if (allColors[i].name.ToLower() == color.ToLower())
                {
                    return allColors[i];
                }
            }

            return null;
        }

        private void CompareToArtkalMinis(string color)
        {
            List<OnlineBeadColor> bestColors = new List<OnlineBeadColor>();

            for(int i = 0;i < 10; i++)
            {
                bestColors.Add(GetBestArktalMiniColorNotInList(color, bestColors));
            }


            color1.BackColor = GetColor(bestColors[0].hex);
            colorLabel1.Text = bestColors[0].name + " #" + bestColors[0].hex + " Diff: " + GetColorDifference(color, bestColors[0].hex);

            color2.BackColor = GetColor(bestColors[1].hex);
            colorLabel2.Text = bestColors[1].name + " #" + bestColors[1].hex + " Diff: " + GetColorDifference(color, bestColors[1].hex);

            color3.BackColor = GetColor(bestColors[2].hex);
            colorLabel3.Text = bestColors[2].name + " #" + bestColors[2].hex + " Diff: " + GetColorDifference(color, bestColors[2].hex);

            color4.BackColor = GetColor(bestColors[3].hex);
            colorLabel4.Text = bestColors[3].name + " #" + bestColors[3].hex + " Diff: " + GetColorDifference(color, bestColors[3].hex);

            color5.BackColor = GetColor(bestColors[4].hex);
            colorLabel5.Text = bestColors[4].name + " #" + bestColors[4].hex + " Diff: " + GetColorDifference(color, bestColors[4].hex);

            color6.BackColor = GetColor(bestColors[5].hex);
            colorLabel6.Text = bestColors[5].name + " #" + bestColors[5].hex + " Diff: " + GetColorDifference(color, bestColors[5].hex);

            color7.BackColor = GetColor(bestColors[6].hex);
            colorLabel7.Text = bestColors[6].name + " #" + bestColors[6].hex + " Diff: " + GetColorDifference(color, bestColors[6].hex);

            color8.BackColor = GetColor(bestColors[7].hex);
            colorLabel8.Text = bestColors[7].name + " #" + bestColors[7].hex + " Diff: " + GetColorDifference(color, bestColors[7].hex);

            color9.BackColor = GetColor(bestColors[8].hex);
            colorLabel9.Text = bestColors[8].name + " #" + bestColors[8].hex + " Diff: " + GetColorDifference(color, bestColors[8].hex);

            color10.BackColor = GetColor(bestColors[9].hex);
            colorLabel10.Text = bestColors[9].name + " #" + bestColors[9].hex + " Diff: " + GetColorDifference(color, bestColors[9].hex);
        }

        private void CompareToArtkalMidis(string color)
        {
            List<OnlineBeadColor> bestColors = new List<OnlineBeadColor>();

            for (int i = 0; i < 10; i++)
            {
                bestColors.Add(GetBestArktalMidiColorNotInList(color, bestColors));
            }


            color1.BackColor = GetColor(bestColors[0].hex);
            colorLabel1.Text = bestColors[0].name + " #" + bestColors[0].hex + " Diff: " + GetColorDifference(color, bestColors[0].hex);

            color2.BackColor = GetColor(bestColors[1].hex);
            colorLabel2.Text = bestColors[1].name + " #" + bestColors[1].hex + " Diff: " + GetColorDifference(color, bestColors[1].hex);

            color3.BackColor = GetColor(bestColors[2].hex);
            colorLabel3.Text = bestColors[2].name + " #" + bestColors[2].hex + " Diff: " + GetColorDifference(color, bestColors[2].hex);

            color4.BackColor = GetColor(bestColors[3].hex);
            colorLabel4.Text = bestColors[3].name + " #" + bestColors[3].hex + " Diff: " + GetColorDifference(color, bestColors[3].hex);

            color5.BackColor = GetColor(bestColors[4].hex);
            colorLabel5.Text = bestColors[4].name + " #" + bestColors[4].hex + " Diff: " + GetColorDifference(color, bestColors[4].hex);

            color6.BackColor = GetColor(bestColors[5].hex);
            colorLabel6.Text = bestColors[5].name + " #" + bestColors[5].hex + " Diff: " + GetColorDifference(color, bestColors[5].hex);

            color7.BackColor = GetColor(bestColors[6].hex);
            colorLabel7.Text = bestColors[6].name + " #" + bestColors[6].hex + " Diff: " + GetColorDifference(color, bestColors[6].hex);

            color8.BackColor = GetColor(bestColors[7].hex);
            colorLabel8.Text = bestColors[7].name + " #" + bestColors[7].hex + " Diff: " + GetColorDifference(color, bestColors[7].hex);

            color9.BackColor = GetColor(bestColors[8].hex);
            colorLabel9.Text = bestColors[8].name + " #" + bestColors[8].hex + " Diff: " + GetColorDifference(color, bestColors[8].hex);

            color10.BackColor = GetColor(bestColors[9].hex);
            colorLabel10.Text = bestColors[9].name + " #" + bestColors[9].hex + " Diff: " + GetColorDifference(color, bestColors[9].hex);
        }

        private void CompareToPerlerMidis(string color)
        {
            List<OnlineBeadColor> bestColors = new List<OnlineBeadColor>();

            for (int i = 0; i < 10; i++)
            {
                bestColors.Add(GetBestPerlerMidiColorNotInList(color, bestColors));
            }


            color1.BackColor = GetColor(bestColors[0].hex);
            colorLabel1.Text = bestColors[0].name + " #" + bestColors[0].hex + " Diff: " + GetColorDifference(color, bestColors[0].hex);

            color2.BackColor = GetColor(bestColors[1].hex);
            colorLabel2.Text = bestColors[1].name + " #" + bestColors[1].hex + " Diff: " + GetColorDifference(color, bestColors[1].hex);

            color3.BackColor = GetColor(bestColors[2].hex);
            colorLabel3.Text = bestColors[2].name + " #" + bestColors[2].hex + " Diff: " + GetColorDifference(color, bestColors[2].hex);

            color4.BackColor = GetColor(bestColors[3].hex);
            colorLabel4.Text = bestColors[3].name + " #" + bestColors[3].hex + " Diff: " + GetColorDifference(color, bestColors[3].hex);

            color5.BackColor = GetColor(bestColors[4].hex);
            colorLabel5.Text = bestColors[4].name + " #" + bestColors[4].hex + " Diff: " + GetColorDifference(color, bestColors[4].hex);

            color6.BackColor = GetColor(bestColors[5].hex);
            colorLabel6.Text = bestColors[5].name + " #" + bestColors[5].hex + " Diff: " + GetColorDifference(color, bestColors[5].hex);

            color7.BackColor = GetColor(bestColors[6].hex);
            colorLabel7.Text = bestColors[6].name + " #" + bestColors[6].hex + " Diff: " + GetColorDifference(color, bestColors[6].hex);

            color8.BackColor = GetColor(bestColors[7].hex);
            colorLabel8.Text = bestColors[7].name + " #" + bestColors[7].hex + " Diff: " + GetColorDifference(color, bestColors[7].hex);

            color9.BackColor = GetColor(bestColors[8].hex);
            colorLabel9.Text = bestColors[8].name + " #" + bestColors[8].hex + " Diff: " + GetColorDifference(color, bestColors[8].hex);

            color10.BackColor = GetColor(bestColors[9].hex);
            colorLabel10.Text = bestColors[9].name + " #" + bestColors[9].hex + " Diff: " + GetColorDifference(color, bestColors[9].hex);
        }

        private OnlineBeadColor GetBestArktalMiniColorNotInList(string color, List<OnlineBeadColor> bestColors)
        {
            int minDiff = 100000000;

            OnlineBeadColor bestColorString = null;

            for (int i = 0; i < artkalColors.Count; i++)
            {
                int diff = GetColorDifference(color, artkalColors[i].hex);

                if (diff < minDiff && !bestColors.Contains(artkalColors[i]))
                {
                    bestColorString = artkalColors[i];

                    minDiff = diff + 0;
                }
            }

            return bestColorString;
        }

        private OnlineBeadColor GetBestArktalMidiColorNotInList(string color, List<OnlineBeadColor> bestColors)
        {
            int minDiff = 100000000;

            OnlineBeadColor bestColorString = null;

            for (int i = 0; i < artkalMidiColors.Count; i++)
            {
                int diff = GetColorDifference(color, artkalMidiColors[i].hex);

                if (diff < minDiff && !bestColors.Contains(artkalMidiColors[i]))
                {
                    bestColorString = artkalMidiColors[i];

                    minDiff = diff + 0;
                }
            }

            return bestColorString;
        }

        private OnlineBeadColor GetBestPerlerMidiColorNotInList(string color, List<OnlineBeadColor> bestColors)
        {
            int minDiff = 100000000;

            OnlineBeadColor bestColorString = null;

            for (int i = 0; i < perlerMidiColors.Count; i++)
            {
                int diff = GetColorDifference(color, perlerMidiColors[i].hex);

                if (diff < minDiff && !bestColors.Contains(perlerMidiColors[i]))
                {
                    bestColorString = perlerMidiColors[i];

                    minDiff = diff + 0;
                }
            }

            return bestColorString;
        }

        private string GetBestCollectionColorNotInList(string color, List<string> bestColors)
        {
            int minDiff = 100000000;

            string bestColorString = null;

            for (int i = 0; i < perlerColors.Count; i++)
            {
                int diff = GetColorDifference(color, perlerColors[i]);

                if (diff < minDiff && !bestColors.Contains(perlerColors[i]))
                {
                    bestColorString = perlerColors[i];

                    minDiff = diff + 0;
                }
            }

            return bestColorString;
        }

        private void CompareToCollection(string color)
        {
            List<string> bestColors = new List<string>();

            for(int i = 0; i < 10;i++)
            {
                bestColors.Add(GetBestCollectionColorNotInList(color, bestColors));
            }

            color1.BackColor = GetColor(bestColors[0]);
            colorLabel1.Text = " #" + bestColors[0] + " Diff: " + GetColorDifference(color, bestColors[0]);

            color2.BackColor = GetColor(bestColors[1]);
            colorLabel2.Text = " #" + bestColors[1] + " Diff: " + GetColorDifference(color, bestColors[1]);

            color3.BackColor = GetColor(bestColors[2]);
            colorLabel3.Text = " #" + bestColors[2] + " Diff: " + GetColorDifference(color, bestColors[2]);

            color4.BackColor = GetColor(bestColors[3]);
            colorLabel4.Text = " #" + bestColors[3] + " Diff: " + GetColorDifference(color, bestColors[3]);

            color5.BackColor = GetColor(bestColors[4]);
            colorLabel5.Text = " #" + bestColors[4] + " Diff: " + GetColorDifference(color, bestColors[4]);

            color6.BackColor = GetColor(bestColors[5]);
            colorLabel6.Text = " #" + bestColors[5] + " Diff: " + GetColorDifference(color, bestColors[5]);

            color7.BackColor = GetColor(bestColors[6]);
            colorLabel7.Text = " #" + bestColors[6] + " Diff: " + GetColorDifference(color, bestColors[6]);

            color8.BackColor = GetColor(bestColors[7]);
            colorLabel8.Text = " #" + bestColors[7] + " Diff: " + GetColorDifference(color, bestColors[7]);

            color9.BackColor = GetColor(bestColors[8]);
            colorLabel9.Text = " #" + bestColors[8] + " Diff: " + GetColorDifference(color, bestColors[8]);

            color10.BackColor = GetColor(bestColors[9]);
            colorLabel10.Text = " #" + bestColors[9] + " Diff: " + GetColorDifference(color, bestColors[9]);
        }

        private Color GetColor(string color)
        {
            return ColorTranslator.FromHtml("#" + color);
        }

        private int GetColorDifference(string color1, string color2)
        {
            int difference = 0;

            for(int i = 0; i < 6;i += 2)
            {
                int val1 = HexValue(color1.Substring(i, 2));
                int val2 = HexValue(color2.Substring(i, 2));

                difference += (int)Math.Abs(val1 - val2);
            }

            return difference;
        }

        private int HexValue(string hex)
        {
            string values = "0123456789abcdef";

            if (hex.Length != 2) return -1;

            return values.IndexOf(hex[0]) * 16 + values.IndexOf(hex[1]);
        }

        private bool ValidColorString(string color)
        {
            if (color.Length != 6) return false;

            string validChars = "abcdef1234567890";
            for(int i = 0; i < color.Length;i++)
            {
                if (!validChars.Contains(color[i])) return false;
            }

            return true;
        }

        public OnlineBeadColor parseOnlineColor(string line, string site)
        {
            string[] components = line.Split(',');

            OnlineBeadColor newColor = new OnlineBeadColor();
            newColor.name = components[2];
            newColor.hex = components[1];

            newColor.site = site;

            string[] rgb = components[0].Split('-');
            newColor.r = int.Parse(rgb[0]);
            newColor.g = int.Parse(rgb[1]);
            newColor.b = int.Parse(rgb[2]);

            return newColor;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\Personal Projects\Color Picker\artkalColors.txt";
            string[] lines = File.ReadAllLines(path);

            for(int i = 0;i < lines.Length;i++)
            {
                if (lines[i].Split(',').Length == 3)
                {
                    OnlineBeadColor newColor = parseOnlineColor(lines[i], "Arktal");

                    artkalColors.Add(newColor);
                }
            }

            path = @"C:\Personal Projects\Color Picker\perlerColors.txt";
            lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(',').Length == 3)
                {
                    OnlineBeadColor newColor = parseOnlineColor(lines[i], "Perler");

                    perlerMidiColors.Add(newColor);
                }
            }

            path = @"C:\Personal Projects\Color Picker\artkalMidiColors.txt";
            lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Split(',').Length == 3)
                {
                    OnlineBeadColor newColor = parseOnlineColor(lines[i], "Artkal");

                    artkalMidiColors.Add(newColor);
                }
            }

            path = @"C:\Personal Projects\Color Picker\owned colors.txt";
            lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                ownedColors.Add(lines[i].ToLower());
            }

            /*for (int i = 0; i < generatedImageLabels.Length; i++)
            {
                generatedImageLabels[i] = new Label[87];
                for (int x = 0; x < generatedImageLabels[i].Length; x++)
                {
                    generatedImageLabels[i][x] = new Label();
                    this.Controls.Add(generatedImageLabels[i][x]);

                    generatedImageLabels[i][x].Text = "";
                    generatedImageLabels[i][x].AutoSize = false;
                    generatedImageLabels[i][x].Size = new Size(0, 0);

                    generatedImageLabels[i][x].BackColor = Color.FromArgb(0, Color.White);

                    generatedImageLabels[i][x].Location = new Point(804 + 1000, 105 + 1000);
                }
            }*/
        }

        public string RGBToHex(int r, int g, int b)
        {
            return NumToHex(r) + NumToHex(g) + NumToHex(b);
        }

        public string NumToHex(int num)
        {
            if (num > 255 || num < 0) return "";

            string val1 = ConvertHex((num / 16) + "");
            string val2 = ConvertHex((num % 16) + "");


            return val1 + val2;
        }

        public string ConvertHex(string val)
        {
            if (val == "10") return "a";
            if (val == "11") return "b";
            if (val == "12") return "c";
            if (val == "13") return "d";
            if (val == "14") return "e";
            if (val == "15") return "f";

            return val;
        }

        private void catelogButton_Click(object sender, EventArgs e)
        {
            /*
            string path = @"C:\Personal Projects\Color Picker\artkalMidiColors.txt";

            int r = int.Parse(rText.Text);
            int g = int.Parse(gText.Text);
            int b = int.Parse(bText.Text);

            string hex = RGBToHex(r, g, b);

            File.AppendAllText(path, r + "-" + g + "-" + b + "," + hex + "," + nameText.Text.ToUpper() + "\n");

            rText.Text = "";
            gText.Text = "";
            bText.Text = "";
            nameText.Text = "";
            */
            FormatArtkalMinis();
        }

        public void FormatArtkalMinis()
        {
            string path = @"C:\Personal Projects\Color Picker\artkalMiniColors.txt";
            string inputPath = @"C:\Personal Projects\Color Picker\artkalMiniUnparsed.txt";

            string[] lines = File.ReadAllLines(inputPath);

            List<string> colors = new List<string>();
            List<string> names = new List<string>();

            for(int i = 0;i < lines.Length;i++)
            {
                if (lines[i].StartsWith("C"))
                {
                    names.Add(lines[i]);
                }
                else if (lines[i].StartsWith("R"))
                {
                    colors.Add(lines[i]);
                }
                else
                {
                    MessageBox.Show("UnusableLine:\n" + lines[i]);
                }


                if(colors.Count > 0 && names.Count > 0)
                {
                    try
                    {
                        string[] rgbComponents = colors[0].Split(':');

                        int r = int.Parse(rgbComponents[1].Split(' ')[0]);
                        int g = int.Parse(rgbComponents[2].Split(' ')[0]);
                        int b = int.Parse(removeDeadSpace(rgbComponents[3]));

                        string hex = RGBToHex(r, g, b);

                        string name = removeDeadSpace(names[0]);

                        File.AppendAllText(path, r + "-" + g + "-" + b + "," + hex + "," + name.ToUpper() + "\n");

                        names.RemoveAt(0);
                        colors.RemoveAt(0);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Error on line:\n" + colors[0] + "\n" + names[0]);
                        break;
                    }
                }
            }

            MessageBox.Show("Colors Length: " + colors.Count + "\nNames Length: " + names.Count);
        }

        public string removeDeadSpace(string s)
        {
            while(s.EndsWith(' ') || s.EndsWith('\t') || s.EndsWith('\n'))
            {
                s = s.Substring(0, s.Length - 1);
            }

            while (s.StartsWith(' ') || s.StartsWith('\t') || s.StartsWith('\n'))
            {
                s = s.Substring(1);
            }

            return s;
        }

        private int ColorCountSort(ColorCount cc1, ColorCount cc2)
        {
            if (cc1.count != cc2.count) return cc1.count.CompareTo(cc2.count);

            return cc1.color.name.CompareTo(cc2.color.name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!File.Exists(textBox2.Text))
            {
                MessageBox.Show("File does not exist...");
                return;
            }
            Bitmap image = new Bitmap(textBox2.Text);
            int pixelSize = int.Parse(textBox3.Text);

            UpdateCounts(image, pixelSize);
        }

        List<ColorCount> colorCounts = new List<ColorCount>();

        private void UpdateCounts(Bitmap image, int pixelSize)
        {
            colorCounts = new List<ColorCount>();

            for (int i = 0; i < image.Width; i += pixelSize)
            {
                for (int x = 0; x < image.Height; x += pixelSize)
                {
                    if ((int)image.GetPixel(i, x).A == 255)
                    {
                        string color = RGBToHex((int)image.GetPixel(i, x).R, (int)image.GetPixel(i, x).G, (int)image.GetPixel(i, x).B);

                        OnlineBeadColor bestColor = null;

                        if (ValidColorString(color))
                        {
                            if (ArtkalMiniCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMiniColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (perlerMidiCheckBox.Checked)
                            {
                                bestColor = GetBestPerlerMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (artkalMidiCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }

                            if (bestColor != null)
                            {
                                bool inList = false;
                                for (int j = 0; j < colorCounts.Count; j++)
                                {
                                    if (colorCounts[j].color == bestColor)
                                    {
                                        inList = true;
                                        colorCounts[j].count++;

                                        break;
                                    }
                                }

                                if (!inList)
                                {
                                    colorCounts.Add(new ColorCount(bestColor, 1));
                                }
                            }
                        }
                    }
                }
            }

            colorCounts.Sort(ColorCountSort);

            //MessageBox.Show(colorCounts.Count + "");

            listBox1.Items.Clear();

            int count = 0;

            for (int i = 0; i < colorCounts.Count; i++)
            {
                string owned = "";

                if (ownedColors.Contains(colorCounts[i].color.name.ToLower())) owned = " X";

                listBox1.Items.Add(colorCounts[i].color.hex + ", " + colorCounts[i].color.name + ": " + colorCounts[i].count + owned);
                count += colorCounts[i].count;
            }

            label5.Text = "Cost: $" + MathF.Round(count / 1000.0f * 3, 2);
        }

        private void pixel_click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            if (label.BackColor.A != 255) return;

            int r = label.BackColor.R;
            int g = label.BackColor.G;
            int b = label.BackColor.B;

            string hex = RGBToHex(r, g, b);

            exactColor.BackColor = GetColor(hex);
            exactColorCode.Text = hex;

            if (ArtkalMiniCheckBox.Checked)
            {
                CompareToArtkalMinis(hex);
            }
            else if (perlerMidiCheckBox.Checked)
            {
                CompareToPerlerMidis(hex);
            }
            else if (artkalMidiCheckBox.Checked)
            {
                CompareToArtkalMidis(hex);
            }
            else
            {
                CompareToCollection(hex);
            }
        }

        Bitmap originalImage;
        Bitmap generatedImage;

        int pixelWidth = 1;

        int totalGridSize = 850;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox2.Text))
            {
                MessageBox.Show("File does not exist...");
                return;
            }

            button1_Click(sender, e);

            Bitmap importedImage = ClearDeadSpace(new Bitmap(textBox2.Text));

            int pixelSize = int.Parse(textBox3.Text);

            int width = importedImage.Width / pixelSize;
            int height = importedImage.Height / pixelSize;

            int gridSizeWidth = width / 29 + 1;
            int gridSizeHeight = height / 29 + 1;

            pixelWidth = totalGridSize / (29 * gridSizeHeight);
            if (totalGridSize / (29 * gridSizeWidth) < pixelWidth) pixelWidth = totalGridSize / (29 * gridSizeWidth);

            label7.Text = "Current Pixel Width: " + pixelWidth;

            originalImage = new Bitmap(gridSizeWidth * 29 * pixelWidth, gridSizeHeight * 29 * pixelWidth);
            generatedImage = new Bitmap(gridSizeWidth * 29 * pixelWidth, gridSizeHeight * 29 * pixelWidth);

            pictureBox1.Size = originalImage.Size;


            for (int i = 0; i < importedImage.Width; i += pixelSize)
            {
                for (int x = 0; x < importedImage.Height; x += pixelSize)
                {
                    if ((int)importedImage.GetPixel(i, x).A == 255)
                    {
                        string color = RGBToHex((int)importedImage.GetPixel(i, x).R, (int)importedImage.GetPixel(i, x).G, (int)importedImage.GetPixel(i, x).B);
                        OnlineBeadColor bestColor = null;

                        if (ValidColorString(color))
                        {
                            if (ArtkalMiniCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMiniColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (perlerMidiCheckBox.Checked)
                            {
                                bestColor = GetBestPerlerMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (artkalMidiCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }

                            if (bestColor != null)
                            {
                                for(int j = 0; j < pixelWidth;j ++)
                                {
                                    for(int y = 0; y < pixelWidth; y++)
                                    {
                                        generatedImage.SetPixel(i * pixelWidth / pixelSize + j, x * pixelWidth / pixelSize + y, Color.FromArgb(bestColor.r, bestColor.g, bestColor.b));
                                        originalImage.SetPixel(i * pixelWidth / pixelSize + j, x * pixelWidth / pixelSize + y, Color.FromArgb(importedImage.GetPixel(i, x).ToArgb()));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (checkBox1.Checked)
            {
                pictureBox1.Image = generatedImage;
            }
            else
            {
                pictureBox1.Image = originalImage;
            }

            if(checkBox2.Checked)
            {
                checkBox2_CheckedChanged(sender, e);
            }
        }

        PropertyInfo imageRectangleProperty = typeof(PictureBox).GetProperty("ImageRectangle", BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);

        string mostRecentlyPickedColor = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            Bitmap original = (Bitmap)pictureBox1.Image;

            if (original == null) return;
            if (checkBox4.Checked && pencilHexColor != "")
            {
                PencilTool(sender, e);
                return;
            }
            if(checkBox5.Checked)
            {
                EraseTool(sender, e);
                return;
            }

            Color? color = null;

            Rectangle rectangle = (Rectangle)imageRectangleProperty.GetValue(pictureBox1, null);
            if (rectangle.Contains(me.Location))
            {
                using (Bitmap copy = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height))
                {
                    using (Graphics g = Graphics.FromImage(copy))
                    {
                        g.DrawImage(pictureBox1.Image, rectangle);

                        color = copy.GetPixel(me.X, me.Y);
                    }
                }
            }

            if(color.HasValue && color.Value.A > 0)
            {
                string hex = RGBToHex(color.Value.R, color.Value.G, color.Value.B);

                exactColor.BackColor = GetColor(hex);
                exactColorCode.Text = hex;

                OnlineBeadColor onlineColor = null;

                if (ArtkalMiniCheckBox.Checked)
                {
                    CompareToArtkalMinis(hex);

                    for(int i = 0; i < artkalColors.Count;i++)
                    {
                        if (artkalColors[i].hex == hex) onlineColor = artkalColors[i];
                    }
                }
                else if (perlerMidiCheckBox.Checked)
                {
                    CompareToPerlerMidis(hex);

                    for (int i = 0; i < perlerMidiColors.Count; i++)
                    {
                        if (perlerMidiColors[i].hex == hex) onlineColor = perlerMidiColors[i];
                    }
                }
                else if (artkalMidiCheckBox.Checked)
                {
                    CompareToArtkalMidis(hex);

                    for (int i = 0; i < artkalMidiColors.Count; i++)
                    {
                        if (artkalMidiColors[i].hex == hex) onlineColor = artkalMidiColors[i];
                    }
                }
                else
                {
                    CompareToCollection(hex);
                }

                label6.Text = "Value To Change: #" + hex;

                mostRecentlyPickedColor = hex;

                if (onlineColor != null) label6.Text += " (" + onlineColor.name + ")";
            }
        }

        private void PencilTool(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            Bitmap image = originalImage;
            if (checkBox1.Checked) image = generatedImage;

            int x = me.X / pixelWidth;
            int y = me.Y / pixelWidth;

            int r = HexValue(pencilHexColor.Substring(0, 2));
            int g = HexValue(pencilHexColor.Substring(2, 2));
            int b = HexValue(pencilHexColor.Substring(4, 2));

            for(int i = 0; i < pixelWidth;i++)
            {
                for(int j = 0; j < pixelWidth;j++)
                {
                    image.SetPixel(x * pixelWidth + i, y * pixelWidth + j, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = image;

            if (checkBox1.Checked) UpdateCounts(image, pixelWidth);

            checkBox2_CheckedChanged(sender, e);
        }

        private void EraseTool(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            Bitmap image = originalImage;
            if (checkBox1.Checked) image = generatedImage;

            int x = me.X / pixelWidth;
            int y = me.Y / pixelWidth;

            for (int i = 0; i < pixelWidth; i++)
            {
                for (int j = 0; j < pixelWidth; j++)
                {
                    image.SetPixel(x * pixelWidth + i, y * pixelWidth + j, Color.FromArgb(0, 0, 0, 0));
                }
            }

            pictureBox1.Image = image;

            if (checkBox1.Checked) UpdateCounts(image, pixelWidth);

            checkBox2_CheckedChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                pictureBox1.Image = generatedImage;
            }
            else
            {
                pictureBox1.Image = originalImage;
            }

            if (checkBox2.Checked)
            {
                checkBox2_CheckedChanged(sender, e);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)pictureBox1.Image;

            if (checkBox2.Checked && image != null)
            {
                pictureBox1.Image = AddGridLines(image, pixelWidth);
            }
            else
            {
                if (checkBox1.Checked)
                {
                    pictureBox1.Image = generatedImage;
                }
                else
                {
                    pictureBox1.Image = originalImage;
                }
            }
        }

        private Bitmap AddGridLines(Bitmap image, int pixelSize)
        {
            Bitmap newImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    newImage.SetPixel(i, x, image.GetPixel(i, x));
                }
            }

            for (int i = 29 * pixelSize; i < image.Width; i += 29 * pixelSize)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    newImage.SetPixel(i, x, Color.Black);
                }
            }

            for (int i = 29 * pixelSize; i < image.Height; i += 29 * pixelSize)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    newImage.SetPixel(x, i, Color.Black);
                }
            }

            return newImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image;
            if (checkBox1.Checked)
            {
                image = generatedImage;
            }
            else
            {
                image = originalImage;
            }

            if (mostRecentlyPickedColor != "" && image != null)
            {
                string newColor = null;

                if (ValidColorString(textBox4.Text))
                {
                    newColor = textBox4.Text;
                }
                else if (GetColorByName(textBox4.Text) != null)
                {
                    newColor = GetColorByName(textBox4.Text).hex;
                }

                if(newColor != null)
                {
                    for(int i = 0;i < image.Width;i++)
                    {
                        for(int x = 0; x < image.Height;x++)
                        {
                            if(image.GetPixel(i, x).A == 255)
                            {
                                string pixelHex = RGBToHex((int)image.GetPixel(i, x).R, (int)image.GetPixel(i, x).G, (int)image.GetPixel(i, x).B);

                                if(pixelHex == mostRecentlyPickedColor)
                                {
                                    int r = HexValue(newColor.Substring(0, 2));
                                    int g = HexValue(newColor.Substring(2, 2));
                                    int b = HexValue(newColor.Substring(4, 2));

                                    image.SetPixel(i, x, Color.FromArgb(r, g, b));
                                }
                            }
                        }
                    }
                }

                pictureBox1.Image = image;

                if (checkBox2.Checked) checkBox2_CheckedChanged(sender, e);

                if (checkBox1.Checked) UpdateCounts(image, pixelWidth);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;
                
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog1.FileName;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap image = null;

            if (checkBox1.Checked)
            {
                image = generatedImage;
            }
            else
            {
                image = originalImage;
            }

            if (image == null) return;

            image = ClearDeadSpace(image);
            image = ChangeToPixelSize(image, pixelWidth, int.Parse(textBox5.Text));

            if(checkBox2.Checked)
            {
                image = AddGridLines(image, int.Parse(textBox5.Text));
            }

            if (checkBox3.Checked)
            {
                for(int i = 0; i < image.Width;i++)
                {
                    for(int x = 0; x < image.Height;x++)
                    {
                        if(image.GetPixel(i, x).A != 255)
                        {
                            image.SetPixel(i, x, Color.White);
                        }
                    }
                }
            }

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Png Image|*.png";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    image.Save(saveFileDialog1.FileName, ImageFormat.Png);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < originalImage.Width;i++)
            {
                for(int x = 0; x < originalImage.Height;x++)
                {
                    if ((int)originalImage.GetPixel(i, x).A == 255)
                    {
                        string color = RGBToHex((int)originalImage.GetPixel(i, x).R, (int)originalImage.GetPixel(i, x).G, (int)originalImage.GetPixel(i, x).B);
                        OnlineBeadColor bestColor = null;

                        if (ValidColorString(color))
                        {
                            if (ArtkalMiniCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMiniColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (perlerMidiCheckBox.Checked)
                            {
                                bestColor = GetBestPerlerMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }
                            else if (artkalMidiCheckBox.Checked)
                            {
                                bestColor = GetBestArktalMidiColorNotInList(color, new List<OnlineBeadColor>());
                            }

                            if (bestColor != null)
                            {
                                generatedImage.SetPixel(i, x, Color.FromArgb(bestColor.r, bestColor.g, bestColor.b));
                            }
                        }
                    }
                }
            }

            checkBox1_CheckedChanged(sender, e);

            if (checkBox2.Checked) checkBox2_CheckedChanged(sender, e);

            UpdateCounts(generatedImage, pixelWidth);
        }

        private Bitmap ChangeToPixelSize(Bitmap image, int oldPixelWidth, int newPixelWidth)
        {
            Bitmap newImage = new Bitmap(image.Width / oldPixelWidth * newPixelWidth, image.Height / oldPixelWidth * newPixelWidth);

            for (int i = 0; i < image.Width; i += oldPixelWidth)
            {
                for (int x = 0; x < image.Height; x += oldPixelWidth)
                {
                    for (int j = 0; j < newPixelWidth; j++)
                    {
                        for (int y = 0; y < newPixelWidth; y++)
                        {
                            newImage.SetPixel(i * newPixelWidth / oldPixelWidth + j, x * newPixelWidth / oldPixelWidth + y, image.GetPixel(i, x));
                        }
                    }
                }
            }

            return newImage;
        }

        private Bitmap ClearDeadSpace(Bitmap image)
        {
            if (image == null) return null;

            int leftRow = -1;
            int rightRow = image.Width;
            int topColumn = -1;
            int bottomColumn = image.Height;

            for(int i = 0;i < image.Width;i++)
            {
                bool allClear = true;
                for(int x = 0;x < image.Height;x++)
                {
                    if ((int)image.GetPixel(i, x).A == 255)
                    {
                        allClear = false;
                        break;
                    }
                }

                if (!allClear) break;

                leftRow = i;
            }

            for (int i = image.Width - 1; i >= 0; i--)
            {
                bool allClear = true;
                for (int x = 0; x < image.Height; x++)
                {
                    if ((int)image.GetPixel(i, x).A == 255)
                    {
                        allClear = false;
                        break;
                    }
                }

                if (!allClear) break;

                rightRow = i;
            }

            for (int i = image.Height - 1; i >= 0; i--)
            {
                bool allClear = true;
                for (int x = 0; x < image.Width; x++)
                {
                    if ((int)image.GetPixel(x, i).A == 255)
                    {
                        allClear = false;
                        break;
                    }
                }

                if (!allClear) break;

                bottomColumn = i;
            }

            for (int i = 0; i < image.Height; i++)
            {
                bool allClear = true;
                for (int x = 0; x < image.Width; x++)
                {
                    if ((int)image.GetPixel(x, i).A == 255)
                    {
                        allClear = false;
                        break;
                    }
                }

                if (!allClear) break;

                topColumn = i;
            }

            Bitmap newImage = new Bitmap(rightRow - leftRow - 1, bottomColumn - topColumn - 1);


            int row = 0;
            int column = 0;
            for(int i = leftRow + 1; i < rightRow;i++)
            {
                column = 0;
                for(int x = topColumn + 1; x < bottomColumn;x++)
                {
                    newImage.SetPixel(row, column, image.GetPixel(i, x));
                    column++;
                }
                row++;
            }

            return newImage;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hex = colorCounts[listBox1.SelectedIndex].color.hex;

            exactColor.BackColor = GetColor(hex);
            exactColorCode.Text = hex;

            OnlineBeadColor onlineColor = null;

            if (ArtkalMiniCheckBox.Checked)
            {
                CompareToArtkalMinis(hex);
            }
            else if (perlerMidiCheckBox.Checked)
            {
                CompareToPerlerMidis(hex);
            }
            else if (artkalMidiCheckBox.Checked)
            {
                CompareToArtkalMidis(hex);
            }
            else
            {
                CompareToCollection(hex);
            }

            label6.Text = "Value To Change: #" + hex;

            mostRecentlyPickedColor = hex;

            label6.Text += " (" + colorCounts[listBox1.SelectedIndex].color.name + ")";
        }

        public string pencilHexColor = "";

        private void button7_Click(object sender, EventArgs e)
        {
            string color = textBox4.Text.ToLower();
            string hex = "";
            OnlineBeadColor onlineColor = null;

            if(ValidColorString(color))
            {
                hex = color;
            }
            else
            {
                for(int i = 0;i < artkalColors.Count;i++)
                {
                    if (artkalColors[i].name.ToLower() == color)
                    {
                        onlineColor = artkalColors[i];
                        hex = onlineColor.hex;
                        break;
                    }
                }

                for (int i = 0; i < artkalMidiColors.Count; i++)
                {
                    if (artkalMidiColors[i].name.ToLower() == color)
                    {
                        onlineColor = artkalMidiColors[i];
                        hex = onlineColor.hex;
                        break;
                    }
                }

                for (int i = 0; i < perlerMidiColors.Count; i++)
                {
                    if (perlerMidiColors[i].name.ToLower() == color)
                    {
                        onlineColor = perlerMidiColors[i];
                        hex = onlineColor.hex;
                        break;
                    }
                }
            }

            if(hex != "")
            {
                label6.Text = "Value To Change: #" + hex;

                mostRecentlyPickedColor = hex;
                pencilHexColor = hex;

                pencilLabel.Text = "#" + hex;

                if (onlineColor != null)
                {
                    label6.Text += " (" + onlineColor.name + ")";
                    pencilLabel.Text += " (" + onlineColor.name + ")";
                }
            }
            else
            {
                MessageBox.Show("Invalid Color: \"" + color + "\"");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap image = originalImage;
            if (checkBox1.Checked)
            {
                image = generatedImage;
            }

            image = ClearDeadSpace(image);

            Bitmap newImage = FlipXAxis(image);


            if (checkBox1.Checked)
            {
                generatedImage = newImage;
            }
            else
            {
                originalImage = newImage;
            }

            pictureBox1.Image = newImage;

            checkBox2_CheckedChanged(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap image = originalImage;
            if (checkBox1.Checked)
            {
                image = generatedImage;
            }

            image = ClearDeadSpace(image);

            Bitmap newImage = FlipYAxis(image);

            if (checkBox1.Checked)
            {
                generatedImage = newImage;
            }
            else
            {
                originalImage = newImage;
            }

            pictureBox1.Image = newImage;

            checkBox2_CheckedChanged(sender, e);
        }


        private Bitmap FlipXAxis(Bitmap image)
        {
            Bitmap newImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for(int i = 0;i < image.Width;i++)
            {
                for(int x = 0; x < image.Height;x++)
                {
                    newImage.SetPixel(i, image.Height - x - 1, image.GetPixel(i, x));
                }
            }

            return newImage;
        }

        private Bitmap FlipYAxis(Bitmap image)
        {
            Bitmap newImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            for (int i = 0; i < image.Width; i++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    newImage.SetPixel(image.Width - i - 1, x, image.GetPixel(i, x));
                }
            }

            return newImage;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            IsolateColor(mostRecentlyPickedColor);
        }

        public void IsolateColor(string hex)
        {
            Bitmap newImage = null;

            if (checkBox1.Checked)
            {
                newImage = generatedImage;
            }
            else
            {
                newImage = originalImage;
            }

            for (int i = 0; i < pictureBox1.Image.Width; i++)
            {
                for (int x = 0; x < pictureBox1.Image.Height; x++)
                {
                    if (newImage.GetPixel(i, x).A > 0)
                    {
                        if (hex.ToLower() != RGBToHex(newImage.GetPixel(i, x).R, newImage.GetPixel(i, x).G, newImage.GetPixel(i, x).B).ToLower())
                        {
                            newImage.SetPixel(i, x, Color.FromArgb(255 / 2, newImage.GetPixel(i, x).R, newImage.GetPixel(i, x).G, newImage.GetPixel(i, x).B));
                        }
                        else
                        {
                            newImage.SetPixel(i, x, Color.FromArgb(255, newImage.GetPixel(i, x).R, newImage.GetPixel(i, x).G, newImage.GetPixel(i, x).B));
                        }
                    }
                }
            }

            if (checkBox2.Checked) newImage = AddGridLines(newImage, pixelWidth);

            pictureBox1.Image = newImage;
        }

        public void UnisolateColor()
        {
            Bitmap newImage = null;

            if (checkBox1.Checked)
            {
                newImage = generatedImage;
            }
            else
            {
                newImage = originalImage;
            }

            for (int i = 0; i < pictureBox1.Image.Width; i++)
            {
                for (int x = 0; x < pictureBox1.Image.Height; x++)
                {
                    if(newImage.GetPixel(i, x).A > 0)
                    {
                        newImage.SetPixel(i, x, Color.FromArgb(255, newImage.GetPixel(i, x)));
                    }
                }
            }

            if (checkBox2.Checked) newImage = AddGridLines(newImage, pixelWidth);

            pictureBox1.Image = newImage;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UnisolateColor();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                totalGridSize = 850 / 2;
            }
            else
            {
                totalGridSize = 850;
            }

            pictureBox1.Size = new Size(totalGridSize, totalGridSize);

            button2_Click(sender, e);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                totalGridSize = 850 * 2 / 3;
            }
            else
            {
                totalGridSize = 850;
            }

            pictureBox1.Size = new Size(totalGridSize, totalGridSize);

            button2_Click(sender, e);
        }
    }
}
