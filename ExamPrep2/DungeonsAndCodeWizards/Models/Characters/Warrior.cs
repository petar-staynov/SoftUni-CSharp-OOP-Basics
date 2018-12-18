using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Interfaces;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const int defaultBaseHealth = 100;
        private const int defaultBaseArmor = 50;
        private const int defaultBaseAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, defaultBaseHealth, defaultBaseArmor, defaultBaseAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }

        private void EnsureNoFriendlyFire(Character character)
        {
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
        }
    }
}