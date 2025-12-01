using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BarnCaseApi
{
    public partial class Production : Form
    {
        private List<FarmManagement.SimpleAnimal> farmAnimals;
        private FarmManagement mainForm;
        public readonly CultureInfo dollarCulture = CultureInfo.GetCultureInfo("en-US");

        private Timer cowTimer = new Timer();
        private Timer sheepTimer = new Timer();
        private Timer chickenTimer = new Timer();

        public Production(List<FarmManagement.SimpleAnimal> animals, FarmManagement mainForm)
        {
            InitializeComponent();

            this.farmAnimals = animals;
            this.mainForm = mainForm;

            cowTimer.Interval = 1000;
            sheepTimer.Interval = 1000;
            chickenTimer.Interval = 1000;

            cowTimer.Tick += CowTimer_Tick;
            sheepTimer.Tick += SheepTimer_Tick;
            chickenTimer.Tick += ChickenTimer_Tick;

            UpdateButtons();
            RefreshMoneyLabel();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

    
      
        private void RefreshMoneyLabel()
        {
            lblMoney.Text = "Cash: " + mainForm.GetMoney().ToString("C", dollarCulture);
        }


        private void UpdateButtons()
        {
            bool cowExists = farmAnimals.Any(a => a.Type == "Cow");
            bool sheepExists = farmAnimals.Any(a => a.Type == "Sheep");
            bool chickenExists = farmAnimals.Any(a => a.Type == "Chicken");

            btnCow.Enabled = cowExists;
            btnSheep.Enabled = sheepExists;
            btnChicken.Enabled = chickenExists;
        }

        
        private void btnCow_Click(object sender, EventArgs e)
        {
            progressCow.Value = 0;
            cowTimer.Start();
        }

        private void CowTimer_Tick(object sender, EventArgs e)
        {
            if (progressCow.Value < 100)
            {
                progressCow.Value += 10;
            }
            else
            {
                cowTimer.Stop();
                mainForm.SetMoney(mainForm.GetMoney() + 15);
                RefreshMoneyLabel();
                MessageBox.Show("Cow produced Milk (+$15)");
            }
        }

      
        private void btnSheep_Click(object sender, EventArgs e)
        {
            progressSheep.Value = 0;
            sheepTimer.Start();
        }

        private void SheepTimer_Tick(object sender, EventArgs e)
        {
            if (progressSheep.Value < 100)
            {
                progressSheep.Value += 10;
            }
            else
            {
                sheepTimer.Stop();
                mainForm.SetMoney(mainForm.GetMoney() + 25);
                RefreshMoneyLabel();
                MessageBox.Show("Sheep produced Wool (+$25)");
            }
        }

     
        private void btnChicken_Click(object sender, EventArgs e)
        {
            progressChicken.Value = 0;
            chickenTimer.Start();
        }

        private void ChickenTimer_Tick(object sender, EventArgs e)
        {
            if (progressChicken.Value < 100)
            {
                progressChicken.Value += 20;
            }
            else
            {
                chickenTimer.Stop();
                mainForm.SetMoney(mainForm.GetMoney() + 5);
                RefreshMoneyLabel();
                MessageBox.Show("Chicken laid Eggs (+$5)");
            }
        }

       
        private void PicToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }
    }
}
