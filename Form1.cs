using System.Runtime.InteropServices;

namespace TestApp
{
    public partial class Form1 : Form
    {
        int secondaryCounter = 0;
        string[] queue = new string[2];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            queue[0] = "0";
            queue[1] = "0";
        }

        // Primary Runes

        private void button43_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Test?");
            Console.ReadLine();

            // Import Runes


            int[] perkIds = new int[9];

            // Blocks

            // Buttons 1-5 Control Primary Rune

            var primaryStyle = "";
            if (button1.BackColor == SystemColors.Control)
            {
                primaryStyle = "8000";
            }
            else if (button2.BackColor == SystemColors.Control)
            {
                primaryStyle = "8100";
            }
            else if (button3.BackColor == SystemColors.Control)
            {
                primaryStyle = "8200";
            }
            else if (button4.BackColor == SystemColors.Control)
            {
                primaryStyle = "8400";
            }
            else if (button5.BackColor == SystemColors.Control)
            {
                primaryStyle = "8300";
            }
            else
            {
                Console.WriteLine("No Primary Rune Chosen");
            }

            // Buttons 6-19 Control Primary Subrunes

            // Buttons 6-9 Control First Keystone at Index 0
            if (button9.BackColor == SystemColors.Control)
            {
                perkIds[0] = Int32.Parse(button9.Text);
            }
            else if (button8.BackColor == SystemColors.Control)
            {
                perkIds[0] = Int32.Parse(button8.Text);
            }
            else if (button7.BackColor == SystemColors.Control)
            {
                perkIds[0] = Int32.Parse(button7.Text);
            }
            else if (button6.BackColor == SystemColors.Control)
            {
                perkIds[0] = Int32.Parse(button6.Text);
            }
            else
            {
                Console.WriteLine("First Keystone Not Chosen");
            }

            // Buttons 10-12 Control Second Keystone at Index 1
            if (button12.BackColor == SystemColors.Control)
            {
                perkIds[1] = Int32.Parse(button12.Text);
            }
            else if (button11.BackColor == SystemColors.Control)
            {
                perkIds[1] = Int32.Parse(button11.Text);
            }
            else if (button10.BackColor == SystemColors.Control)
            {
                perkIds[1] = Int32.Parse(button10.Text);
            }
            else
            {
                Console.WriteLine("Second Keystone Not Chosen");
            }

            // Buttons 13-15 Control Third Keystone at Index 2
            if (button15.BackColor == SystemColors.Control)
            {
                perkIds[2] = Int32.Parse(button15.Text);
            }
            else if (button14.BackColor == SystemColors.Control)
            {
                perkIds[2] = Int32.Parse(button14.Text);
            }
            else if (button13.BackColor == SystemColors.Control)
            {
                perkIds[2] = Int32.Parse(button13.Text);
            }
            else
            {
                Console.WriteLine("Third Keystone Not Chosen");
            }

            // Buttons 16 - 19 Control Fourth Keystone at Index 3

            if (button19.BackColor == SystemColors.Control)
            {
                perkIds[3] = Int32.Parse(button19.Text);
            }
            else if (button18.BackColor == SystemColors.Control)
            {
                perkIds[3] = Int32.Parse(button18.Text);
            }
            else if (button17.BackColor == SystemColors.Control)
            {
                perkIds[3] = Int32.Parse(button17.Text);
            }
            else if (button16.BackColor == SystemColors.Control)
            {
                perkIds[3] = Int32.Parse(button16.Text);
            }
            else
            {
                Console.WriteLine("Fourth Keytsone Not Chosen");
            }

            // Buttons 20 - 23 Control Secondary Rune

            var secondaryStyle = "";

            if (button23.BackColor == SystemColors.Control)
            {
                if (button23.Text == "Precision")
                {
                    secondaryStyle = "8000";
                }
                else
                {
                    secondaryStyle = "8100";
                }
            }
            else if (button22.BackColor == SystemColors.Control)
            {
                if (button22.Text == "Domination")
                {
                    secondaryStyle = "8100";
                }
                else
                {
                    secondaryStyle = "8200";
                }
            }
            else if (button21.BackColor == SystemColors.Control)
            {
                if (button21.Text == "Sorcery")
                {
                    secondaryStyle = "8200";
                }
                else
                {
                    secondaryStyle = "8400";
                }
            }
            else if (button20.BackColor == SystemColors.Control)
            {
                if (button20.Text == "Resolve")
                {
                    secondaryStyle = "8400";
                }
                else
                {
                    secondaryStyle = "8300";
                }
            }
            else
            {
                Console.WriteLine("Secondary Rune Not Chosen");
            }

            // Buttons 24-33 Control Secondary Subrunes


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
            secondaryCounter = 0;
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

            button24.Image = null;
            button25.Image = null;
            button26.Image = null;
            button27.Image = null;
            button28.Image = null;
            button29.Image = null;
            button30.Image = null;
            button31.Image = null;
            button32.Image = null;
            button33.Image = null;


        }

        private void setPrecisionPrimary()
        {
            button16.Visible = false;
            button6.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.Image = Image.FromFile(currentDirectory + "\\PressTheAttack.png");
            button8.Image = Image.FromFile(currentDirectory + "\\LethalTempo.png");
            button7.Image = Image.FromFile(currentDirectory + "\\FleetFootwork.png");
            button6.Image = Image.FromFile(currentDirectory + "\\Conquerer.png");
            button12.Image = Image.FromFile(currentDirectory + "\\Overheal.png");
            button11.Image = Image.FromFile(currentDirectory + "\\Triumph.png");
            button10.Image = Image.FromFile(currentDirectory + "\\PresenceOfMind.png");
            button15.Image = Image.FromFile(currentDirectory + "\\LegendAlacrity.png");
            button14.Image = Image.FromFile(currentDirectory + "\\LegendTenacity.png");
            button13.Image = Image.FromFile(currentDirectory + "\\LegendBloodline.png");
            button19.Image = Image.FromFile(currentDirectory + "\\CoupDeGrace.png");
            button18.Image = Image.FromFile(currentDirectory + "\\Cutdown.png");
            button17.Image = Image.FromFile(currentDirectory + "\\LastStand.png");

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
            button23.Image = Image.FromFile(currentDirectory + "\\Domination.png");
            button23.Text = "Domination";
            button22.Image = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button22.Text = "Sorcery";
            button21.Image = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.Image = Image.FromFile(currentDirectory + "\\Inspiration.png");
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
            secondaryCounter = 0;
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

            button24.Image = null;
            button25.Image = null;
            button26.Image = null;
            button27.Image = null;
            button28.Image = null;
            button29.Image = null;
            button30.Image = null;
            button31.Image = null;
            button32.Image = null;
            button33.Image = null;
        }

        private void setDominationPrimary()
        {
            button16.Visible = true;
            button6.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.Image = Image.FromFile(currentDirectory + "\\Electrocute.png");
            button8.Image = Image.FromFile(currentDirectory + "\\Predator.png");
            button7.Image = Image.FromFile(currentDirectory + "\\DarkHarvest.png");
            button6.Image = Image.FromFile(currentDirectory + "\\HailOfBlades.png");
            button12.Image = Image.FromFile(currentDirectory + "\\CheapShot.png");
            button11.Image = Image.FromFile(currentDirectory + "\\TasteOfBlood.png");
            button10.Image = Image.FromFile(currentDirectory + "\\SuddenImpact.png");
            button15.Image = Image.FromFile(currentDirectory + "\\ZombieWard.png");
            button14.Image = Image.FromFile(currentDirectory + "\\GhostPoro.png");
            button13.Image = Image.FromFile(currentDirectory + "\\EyeballCollection.png");
            button19.Image = Image.FromFile(currentDirectory + "\\TreasureHunter.png");
            button18.Image = Image.FromFile(currentDirectory + "\\IngeniousHunter.png");
            button17.Image = Image.FromFile(currentDirectory + "\\RelentlessHunter.png");
            button16.Image = Image.FromFile(currentDirectory + "\\UltimateHunter.png");

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
            button23.Image = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.Image = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button22.Text = "Sorcery";
            button21.Image = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.Image = Image.FromFile(currentDirectory + "\\Inspiration.png");
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
            secondaryCounter = 0;
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

            button24.Image = null;
            button25.Image = null;
            button26.Image = null;
            button27.Image = null;
            button28.Image = null;
            button29.Image = null;
            button30.Image = null;
            button31.Image = null;
            button32.Image = null;
            button33.Image = null;
        }

        private void setSorceryPrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.Image = Image.FromFile(currentDirectory + "\\SummonAery.png");
            button8.Image = Image.FromFile(currentDirectory + "\\ArcaneComet.png");
            button7.Image = Image.FromFile(currentDirectory + "\\PhaseRush.png");
            button12.Image = Image.FromFile(currentDirectory + "\\NullifyingOrb.png");
            button11.Image = Image.FromFile(currentDirectory + "\\ManaflowBand.png");
            button10.Image = Image.FromFile(currentDirectory + "\\NimbusCloak.png");
            button15.Image = Image.FromFile(currentDirectory + "\\Transcendence.png");
            button14.Image = Image.FromFile(currentDirectory + "\\Celerity.png");
            button13.Image = Image.FromFile(currentDirectory + "\\AbsoluteFocus.png");
            button19.Image = Image.FromFile(currentDirectory + "\\Scorch.png");
            button18.Image = Image.FromFile(currentDirectory + "\\Waterwalking.png");
            button17.Image = Image.FromFile(currentDirectory + "\\GatheringStorm.png");

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
            button23.Image = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.Image = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.Image = Image.FromFile(currentDirectory + "\\Resolve.png");
            button21.Text = "Resolve";
            button20.Image = Image.FromFile(currentDirectory + "\\Inspiration.png");
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
            secondaryCounter = 0;
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

            button24.Image = null;
            button25.Image = null;
            button26.Image = null;
            button27.Image = null;
            button28.Image = null;
            button29.Image = null;
            button30.Image = null;
            button31.Image = null;
            button32.Image = null;
            button33.Image = null;

        }

        private void setResolvePrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.Image = Image.FromFile(currentDirectory + "\\GraspOfTheUndying.png");
            button8.Image = Image.FromFile(currentDirectory + "\\Aftershock.png");
            button7.Image = Image.FromFile(currentDirectory + "\\Guardian.png");
            button12.Image = Image.FromFile(currentDirectory + "\\Demolish.png");
            button11.Image = Image.FromFile(currentDirectory + "\\FontOfLife.png");
            button10.Image = Image.FromFile(currentDirectory + "\\ShieldBash.png");
            button15.Image = Image.FromFile(currentDirectory + "\\Conditioning.png");
            button14.Image = Image.FromFile(currentDirectory + "\\SecondWind.png");
            button13.Image = Image.FromFile(currentDirectory + "\\BonePlating.png");
            button19.Image = Image.FromFile(currentDirectory + "\\Overgrowth.png");
            button18.Image = Image.FromFile(currentDirectory + "\\Revitalize.png");
            button17.Image = Image.FromFile(currentDirectory + "\\Unflinching.png");

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
            button23.Image = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.Image = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.Image = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button21.Text = "Sorcery";
            button20.Image = Image.FromFile(currentDirectory + "\\Inspiration.png");
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
            secondaryCounter = 0;
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

            button24.Image = null;
            button25.Image = null;
            button26.Image = null;
            button27.Image = null;
            button28.Image = null;
            button29.Image = null;
            button30.Image = null;
            button31.Image = null;
            button32.Image = null;
            button33.Image = null;
        }

        private void setInspirationPrimary()
        {
            button16.Visible = false;
            button6.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button9.Image = Image.FromFile(currentDirectory + "\\GlacialAugment.png");
            button8.Image = Image.FromFile(currentDirectory + "\\UnsealedSpellbook.png");
            button7.Image = Image.FromFile(currentDirectory + "\\FirstStrike.png");
            button12.Image = Image.FromFile(currentDirectory + "\\HextechFlashtraption.png");
            button11.Image = Image.FromFile(currentDirectory + "\\MagicalFootwear.png");
            button10.Image = Image.FromFile(currentDirectory + "\\PerfectTiming.png");
            button15.Image = Image.FromFile(currentDirectory + "\\FuturesMarket.png");
            button14.Image = Image.FromFile(currentDirectory + "\\MinionDematerializer.png");
            button13.Image = Image.FromFile(currentDirectory + "\\BiscuitDelivery.png");
            button19.Image = Image.FromFile(currentDirectory + "\\CosmicInsight.png");
            button18.Image = Image.FromFile(currentDirectory + "\\ApproachVelocity.png");
            button17.Image = Image.FromFile(currentDirectory + "\\TimeWarpTonic.png");

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
            button23.Image = Image.FromFile(currentDirectory + "\\Precision.png");
            button23.Text = "Precision";
            button22.Image = Image.FromFile(currentDirectory + "\\Domination.png");
            button22.Text = "Domination";
            button21.Image = Image.FromFile(currentDirectory + "\\Sorcery.png");
            button21.Text = "Sorcery";
            button20.Image = Image.FromFile(currentDirectory + "\\Resolve.png");
            button20.Text = "Resolve";
        }



        // Secondary Runes

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
            secondaryCounter = 0;
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
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.Image = Image.FromFile(currentDirectory + "\\Overheal.png");
            button25.Image = Image.FromFile(currentDirectory + "\\Triumph.png");
            button24.Image = Image.FromFile(currentDirectory + "\\PresenceOfMind.png");
            button29.Image = Image.FromFile(currentDirectory + "\\LegendAlacrity.png");
            button28.Image = Image.FromFile(currentDirectory + "\\LegendTenacity.png");
            button27.Image = Image.FromFile(currentDirectory + "\\LegendBloodline.png");
            button32.Image = Image.FromFile(currentDirectory + "\\CoupDeGrace.png");
            button31.Image = Image.FromFile(currentDirectory + "\\Cutdown.png");
            button30.Image = Image.FromFile(currentDirectory + "\\LastStand.png");


            button26.Text = "9101";
            button25.Text = "9111";
            button24.Text = "8009";
            button29.Text = "9104";
            button28.Text = "9105";
            button27.Text = "9103";
            button32.Text = "8014";
            button31.Text = "8017";
            button30.Text = "8299";
        }

        private void setDominationSecondary()
        {
            button33.Visible = true;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.Image = Image.FromFile(currentDirectory + "\\CheapShot.png");
            button25.Image = Image.FromFile(currentDirectory + "\\TasteOfBlood.png");
            button24.Image = Image.FromFile(currentDirectory + "\\SuddenImpact.png");
            button29.Image = Image.FromFile(currentDirectory + "\\ZombieWard.png");
            button28.Image = Image.FromFile(currentDirectory + "\\GhostPoro.png");
            button27.Image = Image.FromFile(currentDirectory + "\\EyeballCollection.png");
            button33.Image = Image.FromFile(currentDirectory + "\\TreasureHunter.png");
            button32.Image = Image.FromFile(currentDirectory + "\\IngeniousHunter.png");
            button31.Image = Image.FromFile(currentDirectory + "\\RelentlessHunter.png");
            button30.Image = Image.FromFile(currentDirectory + "\\UltimateHunter.png");

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
            secondaryCounter = 0;
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
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.Image = Image.FromFile(currentDirectory + "\\NullifyingOrb.png");
            button25.Image = Image.FromFile(currentDirectory + "\\ManaflowBand.png");
            button24.Image = Image.FromFile(currentDirectory + "\\NimbusCloak.png");
            button29.Image = Image.FromFile(currentDirectory + "\\Transcendence.png");
            button28.Image = Image.FromFile(currentDirectory + "\\Celerity.png");
            button27.Image = Image.FromFile(currentDirectory + "\\AbsoluteFocus.png");
            button32.Image = Image.FromFile(currentDirectory + "\\Scorch.png");
            button31.Image = Image.FromFile(currentDirectory + "\\Waterwalking.png");
            button30.Image = Image.FromFile(currentDirectory + "\\GatheringStorm.png");

            button26.Text = "8224";
            button25.Text = "8226";
            button24.Text = "8275";
            button29.Text = "8210";
            button28.Text = "8234";
            button27.Text = "8233";
            button32.Text = "8237";
            button31.Text = "8232";
            button30.Text = "8236";
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
            secondaryCounter = 0;
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
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.Image = Image.FromFile(currentDirectory + "\\Demolish.png");
            button25.Image = Image.FromFile(currentDirectory + "\\FontOfLife.png");
            button24.Image = Image.FromFile(currentDirectory + "\\ShieldBash.png");
            button29.Image = Image.FromFile(currentDirectory + "\\Conditioning.png");
            button28.Image = Image.FromFile(currentDirectory + "\\SecondWind.png");
            button27.Image = Image.FromFile(currentDirectory + "\\BonePlating.png");
            button32.Image = Image.FromFile(currentDirectory + "\\Overgrowth.png");
            button31.Image = Image.FromFile(currentDirectory + "\\Revitalize.png");
            button30.Image = Image.FromFile(currentDirectory + "\\Unflinching.png");

            button26.Text = "8446";
            button25.Text = "8463";
            button24.Text = "8401";
            button29.Text = "8429";
            button28.Text = "8444";
            button27.Text = "8473";
            button32.Text = "8451";
            button31.Text = "8453";
            button30.Text = "8242";

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
            else if(button20.Text == "Inspiration")
            {
                setInspirationSecondary();
            }
        }

        private void resetSecondaryRI()
        {
            secondaryCounter = 0;
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
            button33.Visible = false;
            var currentDirectory = Environment.CurrentDirectory;
            currentDirectory = currentDirectory + "\\Runes";
            button26.Image = Image.FromFile(currentDirectory + "\\HextechFlashtraption.png");
            button25.Image = Image.FromFile(currentDirectory + "\\MagicalFootwear.png");
            button24.Image = Image.FromFile(currentDirectory + "\\PerfectTiming.png");
            button29.Image = Image.FromFile(currentDirectory + "\\FuturesMarket.png");
            button28.Image = Image.FromFile(currentDirectory + "\\MinionDematerializer.png");
            button27.Image = Image.FromFile(currentDirectory + "\\BiscuitDelivery.png");
            button32.Image = Image.FromFile(currentDirectory + "\\CosmicInsight.png");
            button31.Image = Image.FromFile(currentDirectory + "\\ApproachVelocity.png");
            button30.Image = Image.FromFile(currentDirectory + "\\TimeWarpTonic.png");

            button26.Text = "8306";
            button25.Text = "8304";
            button24.Text = "8313";
            button29.Text = "8321";
            button28.Text = "8316";
            button27.Text = "8345";
            button32.Text = "8347";
            button31.Text = "8410";
            button30.Text = "8352";

        }


        // Stat Mods

        private void button36_Click(object sender, EventArgs e)
        {
            if (button36.BackColor != SystemColors.Control)
            {
                rowReset36();
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
            Console.WriteLine(queue[0]);
            Console.WriteLine(queue[1]);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            rowReset24();
            if (queue[0] == "0" && queue[1] == "0")
            {
                queuePush(button24.Text);
            }
            else
            {
                if (queue[0] != "0" && queue[1] == "0")
                {

                }
                else
                {

                }
            }
        }

        private void rowReset24()
        {
            button24.BackColor = SystemColors.Control;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Desktop;
        }


        private void button25_Click(object sender, EventArgs e)
        {
            
        }

        private void rowReset25()
        {
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Control;
            button26.BackColor = SystemColors.Desktop;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            
        }

        private void rowReset26()
        {
            button24.BackColor = SystemColors.Desktop;
            button25.BackColor = SystemColors.Desktop;
            button26.BackColor = SystemColors.Control;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
        }

        private void rowReset29()
        {
            button29.BackColor = SystemColors.Control;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Desktop;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            
        }

        private void rowReset28()
        {
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Control;
            button27.BackColor = SystemColors.Desktop;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
        }

        private void rowReset27()
        {
            button29.BackColor = SystemColors.Desktop;
            button28.BackColor = SystemColors.Desktop;
            button27.BackColor = SystemColors.Control;
        }
    }
 }