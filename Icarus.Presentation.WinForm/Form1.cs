using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Icarus.Logic;
using Icarus.Logic.Cards;
using Icarus.Logic.Enemies;

namespace Icarus.Presentation.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            Game.Hero = new Hero()
            {
                Name = "TestHero"
            };
            Game.Hero.Reset();

            // Add some cards to the hero's deck
            Game.Hero.Deck.Add(new WildStrike());


            List<IEnemyInstance> enemies = new List<IEnemyInstance>
            {
                new Enemy_TestDummy(), new Enemy_Skeleton(), new Enemy_Zombie()
            };


            GameWorldManager world = new GameWorldManager(Game.Hero, enemies);

            world.Reset(Game.Hero, enemies);

            world.EventManager.OnNewLogMessage += EventManager_OnNewLogMessage;

            world.EventManager.OnPlayerDamageTaken += EventManager_OnPlayerDamageTaken;

            world.CardManager.FillDeck();
            world.CardManager.CalculateEnergyCosts();
            world.CardManager.DrawFirstHand();
            listBoxCards.DisplayMember = "Name";
            foreach (var managerAvailableBaseCard in world.CardManager.AvailableBaseCards)
            {
                this.listBoxCards.Items.Add(managerAvailableBaseCard);
            }

            listBoxCards.DisplayMember = "Name";
            foreach (var managerAvailableBaseCard in world.CardManager.AvailableBaseCards)
            {
                this.listBoxCards.Items.Add(managerAvailableBaseCard);
            }

            listBoxCards.DisplayMember = "Name";
            foreach (var enemy in world.EnemyManager.Enemies)
            {
                this.listBoxEnemy.Items.Add(enemy);
            }
        }

        private void EventManager_OnNewLogMessage(object sender, Logic.Events.Args.NewLogMessageEventArgs e)
        {
            richTextBoxLog.Text += $"{e.LogMessage}" + Environment.NewLine;
        }

       

        private void EventManager_OnPlayerDamageTaken(object sender, Logic.Events.Args.PlayerDamageTakenEventArgs e)
        {
            
        }

        private void listBoxCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCardSelection(listBoxCards.Items[listBoxCards.SelectedIndex] as BaseCard);
        }

        private void UpdateCardSelection(BaseCard baseCard)
        {
            labelCost.Text = baseCard.Cost.ToString();
            groupBoxCardDetail.Text = baseCard.Name.ToString();
            labelDescription.Text = baseCard.Description.ToString();
            labelExhaust.Text = (baseCard.CardUseType == CardUseType.Exhaust ? "Exhaust" : "");
        }

        

        private void listBoxEnemy_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnemyInstance selectedEnemy = (listBoxEnemy.Items[listBoxEnemy.SelectedIndex] as IEnemyInstance);
            labelMonsterCurrentHealth.Text = selectedEnemy.ActualHealth.ToString();
            labelMonsterMaxHealth.Text = selectedEnemy.BaseMaxHealth.ToString();
            labelmonsterName.Text = selectedEnemy.Name.ToString();

            listBoxStatValues.Items.Clear();
            foreach (var selectedEnemyStatusValue in selectedEnemy.StatusValues)
            {
                listBoxStatValues.Items.Add($"{selectedEnemyStatusValue.Key}: {selectedEnemyStatusValue.Value}");
            }
        }




















        private void listBoxCards_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBoxCards_DragDrop(object sender, DragEventArgs e)
        {
            listBoxCards.Items.Add(e.Data.ToString());
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBoxDeck.Items.Add(e.Data.ToString());
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBoxHand.Items.Add(e.Data.ToString());
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBox4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBox4_DragDrop(object sender, DragEventArgs e)
        {
            listBoxExhaust.Items.Add(e.Data.ToString());
        }

        private void listBox3_DragDrop(object sender, DragEventArgs e)
        {
            listBoxDiscard.Items.Add(e.Data.ToString());
        }

        private void listBox3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
