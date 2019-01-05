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
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

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
                new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie()
            };


            GameWorldManager world = new GameWorldManager(Game.Hero, enemies);

            world.Reset(Game.Hero, enemies);

            world.EventManager.OnPlayerDamageTaken += EventManager_OnPlayerDamageTaken;
            world.EventManager.OnPlayerStatusEffectAdded += EventManager_OnPlayerStatusEffectAdded;

            world.CardManager.FillDeck();
            world.CardManager.CalculateEnergyCosts();
            world.CardManager.DrawFirstHand();

            world.HeroManager.TakeDamage(40);


            listBoxCards.DisplayMember = "Name";
            foreach (var managerAvailableBaseCard in world.CardManager.AvailableBaseCards)
            {
                this.listBoxCards.Items.Add(managerAvailableBaseCard);
            }
        }

        private void EventManager_OnPlayerStatusEffectAdded(object sender, Logic.Events.Args.PlayerStatusEffectAddedEventArgs e)
        {
            
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

        private void groupBoxCardDetail_Enter(object sender, EventArgs e)
        {

        }
    }
}
