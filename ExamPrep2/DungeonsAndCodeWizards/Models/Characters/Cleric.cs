using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Interfaces;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const int defaultBaseHealth = 50;
        private const int defaultBaseArmor = 25;
        private const int defaultBaseAbilityPoints = 40;

        public Cleric(string name, Faction faction)
            : base(name, defaultBaseHealth, defaultBaseArmor, defaultBaseAbilityPoints, new Backpack(), faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}