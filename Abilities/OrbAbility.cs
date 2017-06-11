// <copyright file="OrbAbility.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Abilities
{
    using System.Linq;

    using Ensage.SDK.Extensions;

    public abstract class OrbAbility : AutocastAbility
    {
        protected OrbAbility(Ability abiltity)
            : base(abiltity)
        {
        }

        public override float CastPoint
        {
            get
            {
                return this.Owner.AttackPoint();
            }
        }

        public override float Range
        {
            get
            {
                return this.Owner.AttackRange();
            }
        }

        public override float GetDamage(params Unit[] targets)
        {
            var owner = this.Owner;
            if (!targets.Any())
            {
                return owner.MinimumDamage + owner.BonusDamage;
            }

            return owner.GetAttackDamage(targets.First());
        }
    }
}