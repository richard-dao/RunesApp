using System.Runtime.InteropServices;
using PoniLCU;
using static PoniLCU.LeagueClient;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace RunesApp
{
    public partial class Form1 : Form
    {
        class SavedConfig
        {
            public string primary;
            public string secondary;
            public string[] keystones;
            public string name;

            public SavedConfig()
            {
                primary = null;
                secondary = null;
                keystones = null;
                name = null;
            }

            public SavedConfig(string p, string s, string[] ks, string n)
            {
                primary = p;
                secondary = s;
                keystones = ks;
                name = n;
            }
        }
        static string[] queue = new string[2];
        static string[] selectedPerks = new string[9];
        static string primaryRune = "";
        static string secondaryRune = "";
        static string bodyName = "";
        static string stringPerks = "";
        List<SavedConfig> cached = new List<SavedConfig>();
        static LeagueClient leagueClient = new LeagueClient(credentials.cmd);

        private const int CB_SETCUEBANNER = 0x1703;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            queue[0] = "0";
            queue[1] = "0";
            loadFromJSON();
            var currentDirectory = Environment.CurrentDirectory;
            string path = currentDirectory + "\\Runes";
            button1.BackgroundImage = Image.FromFile(path + "\\Precision.png");
            button2.BackgroundImage = Image.FromFile(path + "\\Domination.png");
            button3.BackgroundImage = Image.FromFile(path + "\\Sorcery.png");
            button4.BackgroundImage = Image.FromFile(path + "\\Resolve.png");
            button5.BackgroundImage = Image.FromFile(path + "\\Inspiration.png");

            button36.BackgroundImage = Image.FromFile(path + "\\Adaptive.png");
            button35.BackgroundImage = Image.FromFile(path + "\\AttackSpeed.png");
            button34.BackgroundImage = Image.FromFile(path + "\\AbilityHaste.png");
            button39.BackgroundImage = Image.FromFile(path + "\\Adaptive.png");
            button38.BackgroundImage = Image.FromFile(path + "\\Armor.png");
            button37.BackgroundImage = Image.FromFile(path + "\\Resist.png");
            button42.BackgroundImage = Image.FromFile(path + "\\Health.png");
            button41.BackgroundImage = Image.FromFile(path + "\\Armor.png");
            button40.BackgroundImage = Image.FromFile(path + "\\Resist.png");
        }

        private void readSaved()
        {
            if (primaryRune == "8000")
            {
                setPrecisionPrimary(); // Sets precision keystones ids
                resetPrecision(); // Sets selected background for precision and deletes all other images 
                removePrecisionSecondary(); // Sets image for secondary runes
                secondaryIDPrecisionPrimary();
            }
            else if (primaryRune == "8100")
            {
                setDominationPrimary();
                resetDomination();
                removeDominationSecondary();
                secondaryIDDominationPrimary();
            }
            else if (primaryRune == "8200")
            {
                setSorceryPrimary();
                resetSorcery();
                removeSorcerySecondary();
                secondaryIDSorceryPrimary();
            }
            else if (primaryRune == "8400")
            {
                setResolvePrimary();
                resetResolve();
                removeResolveSecondary();
                secondaryIDResolvePrimary();
            }
            else if (primaryRune == "8300")
            {
                setInspirationPrimary();
                resetInspiration();
                removeInspirationSecondary();
                secondaryIDInspirationPrimary();
            }


            if (secondaryRune == "8000")
            {
                setPrecisionSecondary();
                if (button23.Text == "8000")
                {
                    button23.BackColor = SystemColors.Control;
                }
                else if (button22.Text == "8000")
                {
                    button22.BackColor = SystemColors.Control;
                }
                else if (button21.Text == "8000")
                {
                    button21.BackColor = SystemColors.Control;
                }
                else if (button20.Text == "8000")
                {
                    button20.BackColor = SystemColors.Control;
                }

            }
            else if (secondaryRune == "8100")
            {
                setDominationSecondary();
                if (button23.Text == "8100")
                {
                    button23.BackColor = SystemColors.Control;
                }
                else if (button22.Text == "8100")
                {
                    button22.BackColor = SystemColors.Control;
                }
                else if (button21.Text == "8100")
                {
                    button21.BackColor = SystemColors.Control;
                }
                else if (button20.Text == "8100")
                {
                    button20.BackColor = SystemColors.Control;
                }
            }
            else if (secondaryRune == "8200")
            {
                setSorcerySecondary();
                if (button23.Text == "8200")
                {
                    button23.BackColor = SystemColors.Control;
                }
                else if (button22.Text == "8200")
                {
                    button22.BackColor = SystemColors.Control;
                }
                else if (button21.Text == "8200")
                {
                    button21.BackColor = SystemColors.Control;
                }
                else if (button20.Text == "8200")
                {
                    button20.BackColor = SystemColors.Control;
                }
            }
            else if (secondaryRune == "8400")
            {
                setResolveSecondary();
                if (button23.Text == "8400")
                {
                    button23.BackColor = SystemColors.Control;
                }
                else if (button22.Text == "8400")
                {
                    button22.BackColor = SystemColors.Control;
                }
                else if (button21.Text == "8400")
                {
                    button21.BackColor = SystemColors.Control;
                }
                else if (button20.Text == "8400")
                {
                    button20.BackColor = SystemColors.Control;
                }
            }
            else if (secondaryRune == "8300")
            {
                setInspirationSecondary();
                if (button23.Text == "8300")
                {
                    button23.BackColor = SystemColors.Control;
                }
                else if (button22.Text == "8300")
                {
                    button22.BackColor = SystemColors.Control;
                }
                else if (button21.Text == "8300")
                {
                    button21.BackColor = SystemColors.Control;
                }
                else if (button20.Text == "8300")
                {
                    button20.BackColor = SystemColors.Control;
                }
            }



            setStatModsText();

            for (int i = 0; i < 6; i++)
            {
                // Previously we have 5005 in [6] and [7]
                // Then we have 5002 in [6] and 5005 in [7]
                // Error is, [7] value is being mistaken as [6]
                foreach (Control c in Controls)
                {
                    Button b = c as Button;
                    if (b != null)
                    {
                        if (b.Text == selectedPerks[i])
                        {
                            b.BackColor = SystemColors.Control;
                        }
                    }
                }
            }

            if (selectedPerks[6] == "5008")
            {
                rowReset36();
            }
            else if (selectedPerks[6] == "5005")
            {
                rowReset35();
            }
            else if (selectedPerks[6] == "5007")
            {
                rowReset34();
            }

            if (selectedPerks[7] == "5008")
            {
                rowReset39();
            }
            else if (selectedPerks[7] == "5002")
            {
                rowReset38();
            }
            else if (selectedPerks[7] == "5003")
            {
                rowReset37();
            }

            if (selectedPerks[8] == "5001")
            {
                rowReset42();
            }
            else if (selectedPerks[8] == "5002")
            {
                rowReset41();
            }
            else if (selectedPerks[8] == "5003")
            {
                rowReset40();
            }


            if (primaryRune == "8000")
            {
                removePrecisionSecondary();
            }
            else if (primaryRune == "8100")
            {
                removeDominationSecondary();
            }
            else if (primaryRune == "8200")
            {
                removeSorcerySecondary();
            }
            else if (primaryRune == "8400")
            {
                removeResolveSecondary();
            }
            else if (primaryRune == "8300")
            {
                removeInspirationSecondary();
            }


        }

        private void secondaryIDPrecisionPrimary()
        {
            button23.Text = "8100";
            button22.Text = "8200";
            button21.Text = "8400";
            button20.Text = "8300";
        }

        private void secondaryIDDominationPrimary()
        {
            button23.Text = "8000";
            button22.Text = "8200";
            button21.Text = "8400";
            button20.Text = "8300";
        }

        private void secondaryIDSorceryPrimary()
        {
            button23.Text = "8000";
            button22.Text = "8100";
            button21.Text = "8400";
            button20.Text = "8300";
        }

        private void secondaryIDResolvePrimary()
        {
            button23.Text = "8000";
            button22.Text = "8100";
            button21.Text = "8200";
            button20.Text = "8300";
        }

        private void secondaryIDInspirationPrimary()
        {
            button23.Text = "8000";
            button22.Text = "8100";
            button21.Text = "8200";
            button20.Text = "8400";
        }

        private void setStatModsText()
        {
            if (selectedPerks[6] == "5008")
            {
                button36.Text = "5008";
            }
            else if (selectedPerks[6] == "5005")
            {
                button36.Text = "0";
                button35.Text = "5005";
            }
            else if (selectedPerks[6] == "5007")
            {
                button36.Text = "0";
                button34.Text = "5007";
            }

            if (selectedPerks[7] == "5008")
            {
                button39.Text = "5008";
            }
            else if (selectedPerks[7] == "5002")
            {
                button39.Text = "0";
                button38.Text = "5002";
            }
            else if (selectedPerks[7] == "5003")
            {
                button39.Text = "0";
                button37.Text = "5003";
            }

            if (selectedPerks[8] == "5001")
            {
                button42.Text = "5001";
            }
            else if (selectedPerks[8] == "5002")
            {
                button41.Text = "5002";
            }
            else if (selectedPerks[8] == "5003")
            {
                button40.Text = "5003";
            }

        }
        async static void changeRunes()
        {
            var data = await leagueClient.Request(requestMethod.GET, "/lol-perks/v1/currentpage");
            var dataDeserialized = Newtonsoft.Json.Linq.JObject.Parse(data);
            var id = dataDeserialized["id"];
            var path = "/lol-perks/v1/pages/" + id;
            await leagueClient.Request(requestMethod.DELETE, path);
            var body = "{\"name\":\"" + bodyName + "\",\"primaryStyleId\":" + primaryRune + ",\"subStyleId\":" + secondaryRune + ",\"selectedPerkIds\":" + stringPerks + ",\"current\":true}";
            var request = await leagueClient.Request(requestMethod.POST, "lol-perks/v1/pages", body);

        }

        private static void stringifyPerks()
        {
            stringPerks = "[";
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    stringPerks += selectedPerks[i];
                }
                else
                {
                    stringPerks += selectedPerks[i] + ",";
                }
            }
            stringPerks += "]";
        }
        private void getPrimary()
        {
            if (button1.BackColor == SystemColors.Control)
            {
                primaryRune = "8000";
            }
            else if (button2.BackColor == SystemColors.Control)
            {
                primaryRune = "8100";
            }
            else if (button3.BackColor == SystemColors.Control)
            {
                primaryRune = "8200";
            }
            else if (button4.BackColor == SystemColors.Control)
            {
                primaryRune = "8400";
            }
            else if (button5.BackColor == SystemColors.Control)
            {
                primaryRune = "8300";
            }
            else
            {
                Console.WriteLine("Primary Rune Not Set");
            }
        }

        private void getPrimaryKeystones()
        {
            // Buttons 6-19

            // Row 1 - Buttons 6-9
            if (button9.BackColor == SystemColors.Control)
            {
                selectedPerks[0] = button9.Text;
            }
            else if (button8.BackColor == SystemColors.Control)
            {
                selectedPerks[0] = button8.Text;
            }
            else if (button7.BackColor == SystemColors.Control)
            {
                selectedPerks[0] = button7.Text;
            }
            else if (button6.BackColor == SystemColors.Control)
            {
                selectedPerks[0] = button6.Text;
            }
            else
            {
                Console.WriteLine("Row 1 Primary Keystone Not Set");
            }

            // Row 2 - Buttons 10-12
            if (button12.BackColor == SystemColors.Control)
            {
                selectedPerks[1] = button12.Text;
            }
            else if (button11.BackColor == SystemColors.Control)
            {
                selectedPerks[1] = button11.Text;
            }
            else if (button10.BackColor == SystemColors.Control)
            {
                selectedPerks[1] = button10.Text;
            }
            else
            {
                Console.WriteLine("Row 2 Primary Keystone Not Set");
            }

            // Row 3 - Buttons 13-15
            if (button15.BackColor == SystemColors.Control)
            {
                selectedPerks[2] = button15.Text;
            }
            else if (button14.BackColor == SystemColors.Control)
            {
                selectedPerks[2] = button14.Text;
            }
            else if (button13.BackColor == SystemColors.Control)
            {
                selectedPerks[2] = button13.Text;
            }
            else
            {
                Console.WriteLine("Row 3 Primary Keystone Not Set");
            }

            // Row 4 - Buttons 16-19
            if (button19.BackColor == SystemColors.Control)
            {
                selectedPerks[3] = button19.Text;
            }
            else if (button18.BackColor == SystemColors.Control)
            {
                selectedPerks[3] = button18.Text;
            }
            else if (button17.BackColor == SystemColors.Control)
            {
                selectedPerks[3] = button17.Text;
            }
            else if (button16.BackColor == SystemColors.Control)
            {
                selectedPerks[3] = button16.Text;
            }

        }
        private void getSecondaryKeystones()
        {
            if (queue[0] == "0")
            {
                Console.WriteLine("Secondary Keystone Runes Not Selected");
            }
            else
            {
                selectedPerks[4] = queue[0];
                selectedPerks[5] = queue[1];
            }

        }

        private void export()
        {
            getPrimary();
            getPrimaryKeystones();
            getSecondaryKeystones();
            stringifyPerks();
        }
        private void button43_Click(object sender, EventArgs e)
        {
            // Export Button
            export();
            changeRunes();
            Console.WriteLine(primaryRune);
            Console.WriteLine(secondaryRune);
            Console.WriteLine(selectedPerks[0]);
            Console.WriteLine(selectedPerks[1]);
            Console.WriteLine(selectedPerks[2]);
            Console.WriteLine(selectedPerks[3]);
            Console.WriteLine(selectedPerks[4]);
            Console.WriteLine(selectedPerks[5]);
            Console.WriteLine(selectedPerks[6]);
            Console.WriteLine(selectedPerks[7]);
            Console.WriteLine(selectedPerks[8]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Precision (ID = 8000)
            if (button1.BackColor != SystemColors.Control)
            {
                resetPrecision();
                setPrecisionPrimary();
                removePrecisionSecondary();
            }

        }

        private void resetPrecision()
        {
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Desktop;
            button3.BackColor = SystemColors.Desktop;
            button4.BackColor = SystemColors.Desktop;
            button5.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button9.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button12.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button15.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button19.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button23.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;

            button24.BackgroundImage = null;
            button25.BackgroundImage = null;
            button26.BackgroundImage = null;
            button27.BackgroundImage = null;
            button28.BackgroundImage = null;
            button29.BackgroundImage = null;
            button30.BackgroundImage = null;
            button31.BackgroundImage = null;
            button32.BackgroundImage = null;
            button33.BackgroundImage = null;


        }

        private void setPrecisionPrimary()
        {
            button16.Visible = false;
            button6.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.BackgroundImage = Image.FromFile(currentDirectory + "\\PressTheAttack.png");
            button8.BackgroundImage = Image.FromFile(currentDirectory + "\\LethalTempo.png");
            button7.BackgroundImage = Image.FromFile(currentDirectory + "\\FleetFootwork.png");
            button6.BackgroundImage = Image.FromFile(currentDirectory + "\\Conquerer.png");
            button12.BackgroundImage = Image.FromFile(currentDirectory + "\\Overheal.png");
            button11.BackgroundImage = Image.FromFile(currentDirectory + "\\Triumph.png");
            button10.BackgroundImage = Image.FromFile(currentDirectory + "\\PresenceOfMind.png");
            button15.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendAlacrity.png");
            button14.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendTenacity.png");
            button13.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendBloodline.png");
            button19.BackgroundImage = Image.FromFile(currentDirectory + "\\CoupDeGrace.png");
            button18.BackgroundImage = Image.FromFile(currentDirectory + "\\Cutdown.png");
            button17.BackgroundImage = Image.FromFile(currentDirectory + "\\LastStand.png");

            button9.Text = "8005";
            button8.Text = "8008";
            button7.Text = "8021";
            button6.Text = "8010";
            button12.Text = "9101";
            button11.Text = "9111";
            button10.Text = "8009";
            button15.Text = "9104";
            button14.Text = "9105";
            button13.Text = "9103";
            button19.Text = "8014";
            button18.Text = "8017";
            button17.Text = "8299";

        }

        private void removePrecisionSecondary()
        {
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button23.BackgroundImage = Image.FromFile(currentDirectory + "\\Domination.png");
            button23.Text = "Domination";
            button22.BackgroundImage = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button22.Text = "Sorcery";
            button21.BackgroundImage = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.BackgroundImage = Image.FromFile(currentDirectory + "\\Inspiration.png");
            button20.Text = "Inspiration";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Domination (ID = 8100)
            if (button2.BackColor != SystemColors.Control)
            {
                resetDomination();
                setDominationPrimary();
                removeDominationSecondary();
            }

        }

        private void resetDomination()
        {

            button1.BackColor = SystemColors.Desktop;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Desktop;
            button4.BackColor = SystemColors.Desktop;
            button5.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button9.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button12.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button15.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button19.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button23.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;

            button24.BackgroundImage = null;
            button25.BackgroundImage = null;
            button26.BackgroundImage = null;
            button27.BackgroundImage = null;
            button28.BackgroundImage = null;
            button29.BackgroundImage = null;
            button30.BackgroundImage = null;
            button31.BackgroundImage = null;
            button32.BackgroundImage = null;
            button33.BackgroundImage = null;
        }

        private void setDominationPrimary()
        {
            button16.Visible = true;
            button6.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.BackgroundImage = Image.FromFile(currentDirectory + "\\Electrocute.png");
            button8.BackgroundImage = Image.FromFile(currentDirectory + "\\Predator.png");
            button7.BackgroundImage = Image.FromFile(currentDirectory + "\\DarkHarvest.png");
            button6.BackgroundImage = Image.FromFile(currentDirectory + "\\HailOfBlades.png");
            button12.BackgroundImage = Image.FromFile(currentDirectory + "\\CheapShot.png");
            button11.BackgroundImage = Image.FromFile(currentDirectory + "\\TasteOfBlood.png");
            button10.BackgroundImage = Image.FromFile(currentDirectory + "\\SuddenImpact.png");
            button15.BackgroundImage = Image.FromFile(currentDirectory + "\\ZombieWard.png");
            button14.BackgroundImage = Image.FromFile(currentDirectory + "\\GhostPoro.png");
            button13.BackgroundImage = Image.FromFile(currentDirectory + "\\EyeballCollection.png");
            button19.BackgroundImage = Image.FromFile(currentDirectory + "\\TreasureHunter.png");
            button18.BackgroundImage = Image.FromFile(currentDirectory + "\\IngeniousHunter.png");
            button17.BackgroundImage = Image.FromFile(currentDirectory + "\\RelentlessHunter.png");
            button16.BackgroundImage = Image.FromFile(currentDirectory + "\\UltimateHunter.png");

            button9.Text = "8112";
            button8.Text = "8124";
            button7.Text = "8128";
            button6.Text = "9923";
            button12.Text = "8126";
            button11.Text = "8139";
            button10.Text = "8143";
            button15.Text = "8136";
            button14.Text = "8120";
            button13.Text = "8138";
            button19.Text = "8135";
            button18.Text = "8134";
            button17.Text = "8105";
            button16.Text = "8106";
        }

        private void removeDominationSecondary()
        {
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button23.BackgroundImage = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.BackgroundImage = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button22.Text = "Sorcery";
            button21.BackgroundImage = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.BackgroundImage = Image.FromFile(currentDirectory + "\\Inspiration.png");
            button20.Text = "Inspiration";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Sorcery (ID = 8200)
            if (button3.BackColor != SystemColors.Control)
            {
                resetSorcery();
                setSorceryPrimary();
                removeSorcerySecondary();
            }

        }

        private void resetSorcery()
        {

            button1.BackColor = SystemColors.Desktop;
            button2.BackColor = SystemColors.Desktop;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Desktop;
            button5.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button9.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button12.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button15.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button19.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button23.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;

            button24.BackgroundImage = null;
            button25.BackgroundImage = null;
            button26.BackgroundImage = null;
            button27.BackgroundImage = null;
            button28.BackgroundImage = null;
            button29.BackgroundImage = null;
            button30.BackgroundImage = null;
            button31.BackgroundImage = null;
            button32.BackgroundImage = null;
            button33.BackgroundImage = null;
        }

        private void setSorceryPrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.BackgroundImage = Image.FromFile(currentDirectory + "\\SummonAery.png");
            button8.BackgroundImage = Image.FromFile(currentDirectory + "\\ArcaneComet.png");
            button7.BackgroundImage = Image.FromFile(currentDirectory + "\\PhaseRush.png");
            button12.BackgroundImage = Image.FromFile(currentDirectory + "\\NullifyingOrb.png");
            button11.BackgroundImage = Image.FromFile(currentDirectory + "\\ManaflowBand.png");
            button10.BackgroundImage = Image.FromFile(currentDirectory + "\\NimbusCloak.png");
            button15.BackgroundImage = Image.FromFile(currentDirectory + "\\Transcendence.png");
            button14.BackgroundImage = Image.FromFile(currentDirectory + "\\Celerity.png");
            button13.BackgroundImage = Image.FromFile(currentDirectory + "\\AbsoluteFocus.png");
            button19.BackgroundImage = Image.FromFile(currentDirectory + "\\Scorch.png");
            button18.BackgroundImage = Image.FromFile(currentDirectory + "\\Waterwalking.png");
            button17.BackgroundImage = Image.FromFile(currentDirectory + "\\GatheringStorm.png");

            button9.Text = "8214";
            button8.Text = "8229";
            button7.Text = "8230";
            button12.Text = "8224";
            button11.Text = "8226";
            button10.Text = "8275";
            button15.Text = "8210";
            button14.Text = "8234";
            button13.Text = "8233";
            button19.Text = "8237";
            button18.Text = "8232";
            button17.Text = "8236";
        }

        private void removeSorcerySecondary()
        {
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button23.BackgroundImage = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.BackgroundImage = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.BackgroundImage = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.BackgroundImage = Image.FromFile(currentDirectory + "\\Inspiration.png");
            button20.Text = "Inspiration";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Resolve (ID = 8400)
            if (button4.BackColor != SystemColors.Control)
            {
                resetResolve();
                setResolvePrimary();
                removeResolveSecondary();
            }

        }

        private void resetResolve()
        {

            button1.BackColor = SystemColors.Desktop;
            button2.BackColor = SystemColors.Desktop;
            button3.BackColor = SystemColors.Desktop;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button9.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button12.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button15.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button19.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button23.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;

            button24.BackgroundImage = null;
            button25.BackgroundImage = null;
            button26.BackgroundImage = null;
            button27.BackgroundImage = null;
            button28.BackgroundImage = null;
            button29.BackgroundImage = null;
            button30.BackgroundImage = null;
            button31.BackgroundImage = null;
            button32.BackgroundImage = null;
            button33.BackgroundImage = null;

        }

        private void setResolvePrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.BackgroundImage = Image.FromFile(currentDirectory + "\\GraspOfTheUndying.png");
            button8.BackgroundImage = Image.FromFile(currentDirectory + "\\Aftershock.png");
            button7.BackgroundImage = Image.FromFile(currentDirectory + "\\Guardian.png");
            button12.BackgroundImage = Image.FromFile(currentDirectory + "\\Demolish.png");
            button11.BackgroundImage = Image.FromFile(currentDirectory + "\\FontOfLife.png");
            button10.BackgroundImage = Image.FromFile(currentDirectory + "\\ShieldBash.png");
            button15.BackgroundImage = Image.FromFile(currentDirectory + "\\Conditioning.png");
            button14.BackgroundImage = Image.FromFile(currentDirectory + "\\SecondWind.png");
            button13.BackgroundImage = Image.FromFile(currentDirectory + "\\BonePlating.png");
            button19.BackgroundImage = Image.FromFile(currentDirectory + "\\Overgrowth.png");
            button18.BackgroundImage = Image.FromFile(currentDirectory + "\\Revitalize.png");
            button17.BackgroundImage = Image.FromFile(currentDirectory + "\\Unflinching.png");

            button9.Text = "8437";
            button8.Text = "8439";
            button7.Text = "8465";
            button12.Text = "8446";
            button11.Text = "8463";
            button10.Text = "8401";
            button15.Text = "8429";
            button14.Text = "8444";
            button13.Text = "8473";
            button19.Text = "8451";
            button18.Text = "8453";
            button17.Text = "8242";
        }

        private void removeResolveSecondary()
        {
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button23.BackgroundImage = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.BackgroundImage = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.BackgroundImage = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button21.Text = "Sorcery";
            button20.BackgroundImage = Image.FromFile(currentDirectory + "\\Inspiration.png");
            button20.Text = "Inspiration";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Inspiration (ID = 8300)
            if (button5.BackColor != SystemColors.Control)
            {
                resetInspiration();
                setInspirationPrimary();
                removeInspirationSecondary();

            }

        }

        private void resetInspiration()
        {

            button1.BackColor = SystemColors.Desktop;
            button2.BackColor = SystemColors.Desktop;
            button3.BackColor = SystemColors.Desktop;
            button4.BackColor = SystemColors.Desktop;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button9.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button12.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button15.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button19.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button23.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;

            button24.BackgroundImage = null;
            button25.BackgroundImage = null;
            button26.BackgroundImage = null;
            button27.BackgroundImage = null;
            button28.BackgroundImage = null;
            button29.BackgroundImage = null;
            button30.BackgroundImage = null;
            button31.BackgroundImage = null;
            button32.BackgroundImage = null;
            button33.BackgroundImage = null;
        }

        private void setInspirationPrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.BackgroundImage = Image.FromFile(currentDirectory + "\\GlacialAugment.png");
            button8.BackgroundImage = Image.FromFile(currentDirectory + "\\UnsealedSpellbook.png");
            button7.BackgroundImage = Image.FromFile(currentDirectory + "\\FirstStrike.png");
            button12.BackgroundImage = Image.FromFile(currentDirectory + "\\HextechFlashtraption.png");
            button11.BackgroundImage = Image.FromFile(currentDirectory + "\\MagicalFootwear.png");
            button10.BackgroundImage = Image.FromFile(currentDirectory + "\\PerfectTiming.png");
            button15.BackgroundImage = Image.FromFile(currentDirectory + "\\FuturesMarket.png");
            button14.BackgroundImage = Image.FromFile(currentDirectory + "\\MinionDematerializer.png");
            button13.BackgroundImage = Image.FromFile(currentDirectory + "\\BiscuitDelivery.png");
            button19.BackgroundImage = Image.FromFile(currentDirectory + "\\CosmicInsight.png");
            button18.BackgroundImage = Image.FromFile(currentDirectory + "\\ApproachVelocity.png");
            button17.BackgroundImage = Image.FromFile(currentDirectory + "\\TimeWarpTonic.png");

            button9.Text = "8351";
            button8.Text = "8360";
            button7.Text = "8369";
            button12.Text = "8306";
            button11.Text = "8304";
            button10.Text = "8313";
            button15.Text = "8321";
            button14.Text = "8316";
            button13.Text = "8345";
            button19.Text = "8347";
            button18.Text = "8410";
            button17.Text = "8352";
        }

        private void removeInspirationSecondary()
        {
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button23.BackgroundImage = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.BackgroundImage = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.BackgroundImage = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button21.Text = "Sorcery";
            button20.BackgroundImage = Image.FromFile(currentDirectory + "\\Resolve.png");
            button20.Text = "Resolve";
        }



        // Secondary Runes

        string[] row1 = new string[3];
        string[] row2 = new string[3];
        string[] row3 = new string[4];

        private void button23_Click(object sender, EventArgs e)
        {
            // Will always either be Precision or Domination
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            if (button23.BackColor != SystemColors.Control)
            {
                resetSecondaryPD();
            }


            if (button23.Text == "Precision")
            {
                setPrecisionSecondary();
            }
            else if (button23.Text == "Domination")
            {
                setDominationSecondary();
            }


        }

        private void resetSecondaryPD()
        {

            button23.BackColor = SystemColors.Control;
            button22.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }

        private void setPrecisionSecondary()
        {
            secondaryRune = "8000";
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.BackgroundImage = Image.FromFile(currentDirectory + "\\Overheal.png");
            button25.BackgroundImage = Image.FromFile(currentDirectory + "\\Triumph.png");
            button24.BackgroundImage = Image.FromFile(currentDirectory + "\\PresenceOfMind.png");
            button29.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendAlacrity.png");
            button28.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendTenacity.png");
            button27.BackgroundImage = Image.FromFile(currentDirectory + "\\LegendBloodline.png");
            button32.BackgroundImage = Image.FromFile(currentDirectory + "\\CoupDeGrace.png");
            button31.BackgroundImage = Image.FromFile(currentDirectory + "\\Cutdown.png");
            button30.BackgroundImage = Image.FromFile(currentDirectory + "\\LastStand.png");


            button26.Text = "9101";
            button25.Text = "9111";
            button24.Text = "8009";
            button29.Text = "9104";
            button28.Text = "9105";
            button27.Text = "9103";
            button32.Text = "8014";
            button31.Text = "8017";
            button30.Text = "8299";

            row1[0] = button26.Text;
            row1[1] = button25.Text;
            row1[2] = button24.Text;
            row2[0] = button29.Text;
            row2[1] = button28.Text;
            row2[2] = button27.Text;
            row3[0] = "0";
            row3[1] = button32.Text;
            row3[2] = button31.Text;
            row3[3] = button30.Text;



        }

        private void setDominationSecondary()
        {
            secondaryRune = "8100";
            button33.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.BackgroundImage = Image.FromFile(currentDirectory + "\\CheapShot.png");
            button25.BackgroundImage = Image.FromFile(currentDirectory + "\\TasteOfBlood.png");
            button24.BackgroundImage = Image.FromFile(currentDirectory + "\\SuddenImpact.png");
            button29.BackgroundImage = Image.FromFile(currentDirectory + "\\ZombieWard.png");
            button28.BackgroundImage = Image.FromFile(currentDirectory + "\\GhostPoro.png");
            button27.BackgroundImage = Image.FromFile(currentDirectory + "\\EyeballCollection.png");
            button33.BackgroundImage = Image.FromFile(currentDirectory + "\\TreasureHunter.png");
            button32.BackgroundImage = Image.FromFile(currentDirectory + "\\IngeniousHunter.png");
            button31.BackgroundImage = Image.FromFile(currentDirectory + "\\RelentlessHunter.png");
            button30.BackgroundImage = Image.FromFile(currentDirectory + "\\UltimateHunter.png");

            button26.Text = "8126";
            button25.Text = "8139";
            button24.Text = "8143";
            button29.Text = "8136";
            button28.Text = "8120";
            button27.Text = "8138";
            button33.Text = "8135";
            button32.Text = "8134";
            button31.Text = "8105";
            button30.Text = "8106";

            row1[0] = button26.Text;
            row1[1] = button25.Text;
            row1[2] = button24.Text;
            row2[0] = button29.Text;
            row2[1] = button28.Text;
            row2[2] = button27.Text;
            row3[0] = button33.Text;
            row3[1] = button32.Text;
            row3[2] = button31.Text;
            row3[3] = button30.Text;
        }


        private void button22_Click(object sender, EventArgs e)
        {

            if (button22.BackColor != SystemColors.Control)
            {
                resetSecondaryDS();
            }
            // Will always be either Domination or Sorcery
            if (button22.Text == "Domination")
            {
                setDominationSecondary();
            }
            else if (button22.Text == "Sorcery")
            {
                setSorcerySecondary();
            }

        }

        private void resetSecondaryDS()
        {

            button23.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Control;
            button21.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }
        private void setSorcerySecondary()
        {
            secondaryRune = "8200";
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.BackgroundImage = Image.FromFile(currentDirectory + "\\NullifyingOrb.png");
            button25.BackgroundImage = Image.FromFile(currentDirectory + "\\ManaflowBand.png");
            button24.BackgroundImage = Image.FromFile(currentDirectory + "\\NimbusCloak.png");
            button29.BackgroundImage = Image.FromFile(currentDirectory + "\\Transcendence.png");
            button28.BackgroundImage = Image.FromFile(currentDirectory + "\\Celerity.png");
            button27.BackgroundImage = Image.FromFile(currentDirectory + "\\AbsoluteFocus.png");
            button32.BackgroundImage = Image.FromFile(currentDirectory + "\\Scorch.png");
            button31.BackgroundImage = Image.FromFile(currentDirectory + "\\Waterwalking.png");
            button30.BackgroundImage = Image.FromFile(currentDirectory + "\\GatheringStorm.png");

            button26.Text = "8224";
            button25.Text = "8226";
            button24.Text = "8275";
            button29.Text = "8210";
            button28.Text = "8234";
            button27.Text = "8233";
            button32.Text = "8237";
            button31.Text = "8232";
            button30.Text = "8236";

            row1[0] = button26.Text;
            row1[1] = button25.Text;
            row1[2] = button24.Text;
            row2[0] = button29.Text;
            row2[1] = button28.Text;
            row2[2] = button27.Text;
            row3[0] = "0";
            row3[1] = button32.Text;
            row3[2] = button31.Text;
            row3[3] = button30.Text;
        }


        private void button21_Click(object sender, EventArgs e)
        {
            if (button21.BackColor != SystemColors.Control)
            {
                resetSecondarySR();
            }
            // Will always be either Sorcery or Resolve
            if (button21.Text == "Sorcery")
            {
                setSorcerySecondary();
            }
            else if (button21.Text == "Resolve")
            {
                setResolveSecondary();
            }

        }

        private void resetSecondarySR()
        {

            button23.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Control;
            button20.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }

        private void setResolveSecondary()
        {
            secondaryRune = "8400";
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.BackgroundImage = Image.FromFile(currentDirectory + "\\Demolish.png");
            button25.BackgroundImage = Image.FromFile(currentDirectory + "\\FontOfLife.png");
            button24.BackgroundImage = Image.FromFile(currentDirectory + "\\ShieldBash.png");
            button29.BackgroundImage = Image.FromFile(currentDirectory + "\\Conditioning.png");
            button28.BackgroundImage = Image.FromFile(currentDirectory + "\\SecondWind.png");
            button27.BackgroundImage = Image.FromFile(currentDirectory + "\\BonePlating.png");
            button32.BackgroundImage = Image.FromFile(currentDirectory + "\\Overgrowth.png");
            button31.BackgroundImage = Image.FromFile(currentDirectory + "\\Revitalize.png");
            button30.BackgroundImage = Image.FromFile(currentDirectory + "\\Unflinching.png");

            button26.Text = "8446";
            button25.Text = "8463";
            button24.Text = "8401";
            button29.Text = "8429";
            button28.Text = "8444";
            button27.Text = "8473";
            button32.Text = "8451";
            button31.Text = "8453";
            button30.Text = "8242";

            row1[0] = button26.Text;
            row1[1] = button25.Text;
            row1[2] = button24.Text;
            row2[0] = button29.Text;
            row2[1] = button28.Text;
            row2[2] = button27.Text;
            row3[0] = "0";
            row3[1] = button32.Text;
            row3[2] = button31.Text;
            row3[3] = button30.Text;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (button20.BackColor != SystemColors.Control)
            {
                resetSecondaryRI();
            }
            // Will always be either Resolve or Inspiration
            if (button20.Text == "Resolve")
            {
                setResolveSecondary();
            }
            else if (button20.Text == "Inspiration")
            {
                setInspirationSecondary();
            }
        }

        private void resetSecondaryRI()
        {

            button23.BackColor = SystemColors.Desktop;
            button22.BackColor = SystemColors.Desktop;
            button21.BackColor = SystemColors.Desktop;
            button20.BackColor = SystemColors.Control;
            button26.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button24.BackColor = SystemColors.Desktop;
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }

        private void setInspirationSecondary()
        {
            secondaryRune = "8300";
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.BackgroundImage = Image.FromFile(currentDirectory + "\\HextechFlashtraption.png");
            button25.BackgroundImage = Image.FromFile(currentDirectory + "\\MagicalFootwear.png");
            button24.BackgroundImage = Image.FromFile(currentDirectory + "\\PerfectTiming.png");
            button29.BackgroundImage = Image.FromFile(currentDirectory + "\\FuturesMarket.png");
            button28.BackgroundImage = Image.FromFile(currentDirectory + "\\MinionDematerializer.png");
            button27.BackgroundImage = Image.FromFile(currentDirectory + "\\BiscuitDelivery.png");
            button32.BackgroundImage = Image.FromFile(currentDirectory + "\\CosmicInsight.png");
            button31.BackgroundImage = Image.FromFile(currentDirectory + "\\ApproachVelocity.png");
            button30.BackgroundImage = Image.FromFile(currentDirectory + "\\TimeWarpTonic.png");

            button26.Text = "8306";
            button25.Text = "8304";
            button24.Text = "8313";
            button29.Text = "8321";
            button28.Text = "8316";
            button27.Text = "8345";
            button32.Text = "8347";
            button31.Text = "8410";
            button30.Text = "8352";

            row1[0] = button26.Text;
            row1[1] = button25.Text;
            row1[2] = button24.Text;
            row2[0] = button29.Text;
            row2[1] = button28.Text;
            row2[2] = button27.Text;
            row3[0] = "0";
            row3[1] = button32.Text;
            row3[2] = button31.Text;
            row3[3] = button30.Text;
        }


        // Stat Mods

        private void button36_Click(object sender, EventArgs e)
        {
            if (button36.BackColor != SystemColors.Control)
            {
                rowReset36();
                selectedPerks[6] = "5008";
            }

        }
        private void rowReset36()
        {
            button36.BackColor = SystemColors.Control;
            button35.BackColor = SystemColors.Desktop;
            button34.BackColor = SystemColors.Desktop;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (button35.BackColor != SystemColors.Control)
            {
                rowReset35();
                selectedPerks[6] = "5005";
            }

        }
        private void rowReset35()
        {
            button36.BackColor = SystemColors.Desktop;
            button35.BackColor = SystemColors.Control;
            button34.BackColor = SystemColors.Desktop;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (button34.BackColor != SystemColors.Control)
            {
                rowReset34();
                selectedPerks[6] = "5007";
            }

        }
        private void rowReset34()
        {
            button36.BackColor = SystemColors.Desktop;
            button35.BackColor = SystemColors.Desktop;
            button34.BackColor = SystemColors.Control;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            if (button39.BackColor != SystemColors.Control)
            {
                rowReset39();
                selectedPerks[7] = "5008";
            }

        }
        private void rowReset39()
        {
            button39.BackColor = SystemColors.Control;
            button38.BackColor = SystemColors.Desktop;
            button37.BackColor = SystemColors.Desktop;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (button38.BackColor != SystemColors.Control)
            {
                rowReset38();
                selectedPerks[7] = "5002";
            }

        }
        private void rowReset38()
        {
            button39.BackColor = SystemColors.Desktop;
            button38.BackColor = SystemColors.Control;
            button37.BackColor = SystemColors.Desktop;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (button37.BackColor != SystemColors.Control)
            {
                rowReset37();
                selectedPerks[7] = "5003";
            }

        }
        private void rowReset37()
        {
            button39.BackColor = SystemColors.Desktop;
            button38.BackColor = SystemColors.Desktop;
            button37.BackColor = SystemColors.Control;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            if (button42.BackColor != SystemColors.Control)
            {
                rowReset42();
                selectedPerks[8] = "5001";
            }

        }
        private void rowReset42()
        {
            button42.BackColor = SystemColors.Control;
            button41.BackColor = SystemColors.Desktop;
            button40.BackColor = SystemColors.Desktop;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (button41.BackColor != SystemColors.Control)
            {
                rowReset41();
                selectedPerks[8] = "5002";
            }

        }
        private void rowReset41()
        {
            button42.BackColor = SystemColors.Desktop;
            button41.BackColor = SystemColors.Control;
            button40.BackColor = SystemColors.Desktop;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            if (button40.BackColor != SystemColors.Control)
            {
                rowReset40();
                selectedPerks[8] = "5003";
            }

        }
        private void rowReset40()
        {
            button42.BackColor = SystemColors.Desktop;
            button41.BackColor = SystemColors.Desktop;
            button40.BackColor = SystemColors.Control;
        }


        // Primary Keystones

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor != SystemColors.Control)
            {
                rowReset9();
            }

        }

        private void rowReset9()
        {
            button9.BackColor = SystemColors.Control;
            button8.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor != SystemColors.Control)
            {
                rowReset8();
            }

        }

        private void rowReset8()
        {
            button9.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Control;
            button7.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Desktop;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor != SystemColors.Control)
            {
                rowReset7();
            }

        }

        private void rowReset7()
        {
            button9.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Desktop;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor != SystemColors.Control)
            {
                rowReset6();
            }
        }

        private void rowReset6()
        {
            button9.BackColor = SystemColors.Desktop;
            button8.BackColor = SystemColors.Desktop;
            button7.BackColor = SystemColors.Desktop;
            button6.BackColor = SystemColors.Control;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.BackColor != SystemColors.Control)
            {
                rowReset12();
            }
        }

        private void rowReset12()
        {
            button12.BackColor = SystemColors.Control;
            button11.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Desktop;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.BackColor != SystemColors.Control)
            {
                rowReset11();
            }

        }

        private void rowReset11()
        {
            button12.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Control;
            button10.BackColor = SystemColors.Desktop;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.BackColor != SystemColors.Control)
            {
                rowReset10();
            }

        }

        private void rowReset10()
        {
            button12.BackColor = SystemColors.Desktop;
            button11.BackColor = SystemColors.Desktop;
            button10.BackColor = SystemColors.Control;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.BackColor != SystemColors.Control)
            {
                rowReset15();
            }

        }

        private void rowReset15()
        {
            button15.BackColor = SystemColors.Control;
            button14.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Desktop;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button14.BackColor != SystemColors.Control)
            {
                rowReset14();
            }

        }

        private void rowReset14()
        {
            button15.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Control;
            button13.BackColor = SystemColors.Desktop;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.BackColor != SystemColors.Control)
            {
                rowReset13();
            }

        }

        private void rowReset13()
        {
            button15.BackColor = SystemColors.Desktop;
            button14.BackColor = SystemColors.Desktop;
            button13.BackColor = SystemColors.Control;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (button19.BackColor != SystemColors.Control)
            {
                rowReset19();
            }

        }

        private void rowReset19()
        {
            button19.BackColor = SystemColors.Control;
            button18.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (button18.BackColor != SystemColors.Control)
            {
                rowReset18();
            }
        }

        private void rowReset18()
        {
            button19.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Control;
            button17.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Desktop;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.BackColor != SystemColors.Control)
            {
                rowReset17();
            }
        }

        private void rowReset17()
        {
            button19.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Control;
            button16.BackColor = SystemColors.Desktop;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.BackColor != SystemColors.Control)
            {
                rowReset16();
            }
        }

        private void rowReset16()
        {
            button19.BackColor = SystemColors.Desktop;
            button18.BackColor = SystemColors.Desktop;
            button17.BackColor = SystemColors.Desktop;
            button16.BackColor = SystemColors.Control;
        }



        // Secondary Keystones

        private void queuePop()
        {
            string head = queue[0];
            queue[0] = queue[1];
            queue[1] = "0";
        }

        private void queuePush(string id)
        {
            if (queue[0] == "0")
            {
                queue[0] = id;
            }
            else if (queue[1] == "0")
            {
                queue[1] = id;
            }
            else
            {
                queuePop();
                queue[1] = id;
            }
        }

        private void row1Checker()
        {
            bool inQueue = false;
            for (int i = 0; i < 3; i++)
            {
                if (queue[0] == row1[i])
                {
                    inQueue = true;
                    break;
                }
                else if (queue[1] == row1[i])
                {
                    inQueue = true;
                    break;
                }
            }
            if (!inQueue)
            {
                button24.BackColor = SystemColors.Desktop;
                button25.BackColor = SystemColors.Desktop;
                button26.BackColor = SystemColors.Desktop;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {

            if (button24.BackColor != SystemColors.Control)
            {
                rowReset24();
                string buttonText = button24.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row1[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row2Checker();
            row3Checker();
        }

        private void rowReset24()
        {
            button24.BackColor = SystemColors.Control;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
        }


        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.BackColor != SystemColors.Control)
            {
                rowReset25();
                string buttonText = button25.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row1[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row2Checker();
            row3Checker();
        }

        private void rowReset25()
        {
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Control;
            button26.BackColor = SystemColors.Desktop;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.BackColor != SystemColors.Control)
            {
                rowReset26();
                string buttonText = button26.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row1[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row1[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row2Checker();
            row3Checker();
        }

        private void rowReset26()
        {
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Control;
        }

        private void row2Checker()
        {
            bool inQueue = false;
            for (int i = 0; i < 3; i++)
            {
                if (queue[0] == row2[i])
                {
                    inQueue = true;
                    break;
                }
                else if (queue[1] == row2[i])
                {
                    inQueue = true;
                    break;
                }
            }
            if (!inQueue)
            {
                button29.BackColor = SystemColors.Desktop;
                button28.BackColor = SystemColors.Desktop;
                button27.BackColor = SystemColors.Desktop;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (button29.BackColor != SystemColors.Control)
            {
                rowReset29();
                string buttonText = button29.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row2[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row3Checker();
        }

        private void rowReset29()
        {
            button29.BackColor = SystemColors.Control;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            if (button28.BackColor != SystemColors.Control)
            {
                rowReset28();
                string buttonText = button28.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row2[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row3Checker();
        }

        private void rowReset28()
        {
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Control;
            button27.BackColor = SystemColors.Desktop;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (button27.BackColor != SystemColors.Control)
            {
                rowReset27();
                string buttonText = button27.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (row2[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row2[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row3Checker();
        }

        private void rowReset27()
        {
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Control;
        }


        private void row3Checker()
        {
            bool inQueue = false;
            for (int i = 0; i < 4; i++)
            {
                if (queue[0] == row3[i])
                {
                    inQueue = true;
                    break;
                }
                else if (queue[1] == row3[i])
                {
                    inQueue = true;
                    break;
                }
            }
            if (!inQueue)
            {
                button33.BackColor = SystemColors.Desktop;
                button32.BackColor = SystemColors.Desktop;
                button31.BackColor = SystemColors.Desktop;
                button30.BackColor = SystemColors.Desktop;
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (button33.BackColor != SystemColors.Control)
            {
                rowReset33();
                string buttonText = button33.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row3[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row2Checker();
        }

        private void rowReset33()
        {
            button33.BackColor = SystemColors.Control;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (button32.BackColor != SystemColors.Control)
            {
                rowReset32();
                string buttonText = button32.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row3[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row2Checker();
        }

        private void rowReset32()
        {
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Control;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Desktop;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.BackColor != SystemColors.Control)
            {
                rowReset31();
                string buttonText = button31.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row3[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row2Checker();
        }

        private void rowReset31()
        {
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Control;
            button30.BackColor = SystemColors.Desktop;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (button30.BackColor != SystemColors.Control)
            {
                rowReset30();
                string buttonText = button30.Text;
                if (queue[0] == "0" && queue[1] == "0")
                {
                    queuePush(buttonText);
                }
                else
                {
                    if (queue[0] != "0" && queue[1] == "0") // One Item
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                    else // Two Items
                    {
                        bool inRow = false;
                        for (int i = 0; i < 4; i++)
                        {
                            if (row3[i] == queue[0])
                            {
                                inRow = true;
                                queue[0] = buttonText;
                                break;
                            }
                            else if (row3[i] == queue[1])
                            {
                                inRow = true;
                                queue[1] = buttonText;
                                break;
                            }
                        }
                        if (!inRow)
                        {
                            queuePush(buttonText);
                        }

                    }
                }
            }
            row1Checker();
            row2Checker();
        }

        private void rowReset30()
        {
            button33.BackColor = SystemColors.Desktop;
            button32.BackColor = SystemColors.Desktop;
            button31.BackColor = SystemColors.Desktop;
            button30.BackColor = SystemColors.Control;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedIndex);
            if (comboBox1.SelectedIndex == 0)
            {
                resetPrecision();
                setPrecisionPrimary();
                removePrecisionSecondary();
            }
            else
            {
                SavedConfig curr = cached[comboBox1.SelectedIndex - 1];
                primaryRune = curr.primary;
                secondaryRune = curr.secondary;
                selectedPerks = curr.keystones;
                bodyName = curr.name;
                readSaved();
                export();
            }
        }

        private void loadFromJSON()
        {
            SendMessage(this.comboBox1.Handle, CB_SETCUEBANNER, 0, "Select a Champion");
            var currentDirectory = Environment.CurrentDirectory;
            string path = currentDirectory + "\\saved.json";

            bool fileExists = File.Exists(path);

            if (!fileExists)
            {
                File.Create(path).Close();
            }


            var linesRead = File.ReadLines(path);
            foreach (var lineRead in linesRead)
            {
                SavedConfig deserialized = JsonConvert.DeserializeObject<SavedConfig>(lineRead);
                if (deserialized.name != "")
                {
                    cached.Add(deserialized);
                }
            }

            updateComboBox();

        }

        private void updateComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox1.Items.Add("Add new configuration");

            for (int i = 0; i < cached.Count; i++)
            {
                Console.WriteLine(cached[i]);
                comboBox1.Items.Add(cached[i].name);
            }
        }

        private void saveToJSON()
        {
            SavedConfig a = new SavedConfig(primaryRune, secondaryRune, selectedPerks, bodyName);
            var currentDirectory = Environment.CurrentDirectory;
            string path = currentDirectory + "\\saved.json";

            bool fileExists = File.Exists(path);

            cached.Clear();
            loadFromJSON();


            if (fileExists)
            {
                if (cached.Count == 0)
                {
                    string output = JsonConvert.SerializeObject(a);
                    File.AppendAllLines(path, new string[] { output });
                    cached.Add(a);
                }
                else
                {
                    Console.WriteLine("Makes it here");
                    // Check if this configuration has already been saved
                    Console.WriteLine(cached.Count);
                    bool inCached = false;
                    for (int i = 0; i < cached.Count; i++)
                    {
                        // if yes, update it with new configuration
                        if (cached[i].name == a.name)
                        {
                            inCached = true;
                            cached[i] = a;
                            break;
                        }
                        // else, add new configuration
                        Console.WriteLine("cached[" + i.ToString() + "] is equal to " + cached[i].name);
                    }
                    if (!inCached && a.name != "")
                    {
                        cached.Add(a);
                    }
                    updateJSON();


                }
            }
            else
            {
                // Create file and add new configuration
                string output = JsonConvert.SerializeObject(a);
                File.Create(path).Close();
                File.AppendAllLines(path, new string[] { output });

            }

        }

        private async void button44_Click(object sender, EventArgs e)
        {
            // Save
            export();
            saveToJSON();
            updateComboBox();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            // Delete
            if (comboBox1.SelectedIndex == 0)
            {
                // Do nothing, don't delete anything
            }
            else
            {
                cached.RemoveAt(comboBox1.SelectedIndex - 1);
                updateJSON();
                updateComboBox();
                resetPrecision();
            }
        }

        private void updateJSON()
        {
            var currentDirectory = Environment.CurrentDirectory;
            string path = currentDirectory + "\\saved.json";

            bool fileExists = File.Exists(path);

            File.Delete(path);
            fileExists = File.Exists(path);
            Console.WriteLine(fileExists);
            File.Create(path).Close();
            for (int i = 0; i < cached.Count; i++)
            {
                string output = JsonConvert.SerializeObject(cached[i]);
                Console.WriteLine(output);
                File.AppendAllLines(path, new string[] { output });
            }

            var pythonExePath = Path.Combine(currentDirectory, "Python", "python.exe");
            var scriptPath = Path.Combine(currentDirectory, "Scripts", "save_to_mongodb.py");

            // MongoDB connection parameters
            var mongoUri = "mongodb+srv://rdao2003:<db_password>@runestable.5leyv.mongodb.net/?retryWrites=true&w=majority&appName=RunesTable;
            var dbName = "configurations";
            var collectionName = "JSON Files";

            // Set up the process start information
            var startInfo = new ProcessStartInfo
            {
                FileName = pythonExePath,
                Arguments = $"\"{scriptPath}\" \"{path}\" \"{mongoUri}\" \"{dbName}\" \"{collectionName}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the Python script
            using (var process = Process.Start(startInfo))
            {
                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"Python script error: {error}");
                }
                else
                {
                    Console.WriteLine(output);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bodyName = textBox1.Text;
        }
    }
}