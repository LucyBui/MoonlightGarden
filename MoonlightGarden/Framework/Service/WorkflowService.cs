using MoonlightGarden.Framework.Domain.Master;
using MoonlightGarden.Framework.Domain.Mg;
using MoonlightGarden.Framework.Domain.Misc;
using MoonlightGarden.Framework.Utils;
using MoonlightGarden.Platform.Factory;
using System.Collections.Generic;

namespace MoonlightGarden.Framework.Service
{
    public class WorkflowService
    {
        private FamilyService familyService = AppContext.getBean<FamilyService>();
        private MasterDataService masterDataService = AppContext.getBean<MasterDataService>();
        private ProcessingService processingService = AppContext.getBean<ProcessingService>();
        public List<string> Explore(string familyId, string zoneId)
        {
            Family family = familyService.GetFamily(familyId);
            List<Card> team = family.CombatTeam;
            List<CombatRate> combatTeam = new List<CombatRate>();
            team.ForEach(card => combatTeam.Add(card.Rate));
             
            List<Monster> monsters = masterDataService.GetMonsterInZone(zoneId);
            Monster boss = masterDataService.GetBossFromMonsters(monsters);
            BattleReport log = new BattleReport(family.Profile.Name);
            // your turn
            Monster monsterWeakest = null;
            bool isNotFinish = true;
            while (isNotFinish)
            {
                foreach (CombatRate card in combatTeam)
                {
                    // step 1: choose a target
                    if (monsterWeakest == null)
                    {
                        monsterWeakest = monsters.Weakest(mob => mob.MaxHP);
                        log.Write(BattleReport.FAMILY_CHOOSE_TARGET, family.Profile.Name, monsterWeakest.Name);
                    }
                    // step 2: attack
                    int damage = processingService.Attack(card, monsterWeakest);
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    log.Write(BattleReport.CHARACTER_ATTACK_MONSTER, card.Name, monsterWeakest.Name, damage);
                    monsterWeakest.MaxHP -= damage;
                    // step 3: check target status
                    if (monsterWeakest.MaxHP < 0)
                    {
                        log.Write(BattleReport.DEAD, monsterWeakest.Name);
                        monsters.Remove(monsterWeakest);
                        if (monsters.Count <= 0)
                        {
                            log.Write(BattleReport.YOU_WIN, family.Profile.Name);
                            isNotFinish = false;
                            break;
                        }
                        else
                        {
                            monsterWeakest = null;
                        }
                    }
                }
                // monsters turn
                CombatRate cardWeakest = null;
                foreach (Monster monster in monsters)
                {
                    // step 1: choose a target
                    if (cardWeakest == null)
                    {
                        cardWeakest = combatTeam.Weakest(card => card.MaxHP);
                    }
                    // step 2: attack
                    int damage = processingService.Attack(monster, cardWeakest);
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    log.Write(BattleReport.MONSTER_ATTACK_CHARACTER, cardWeakest.Name, monster.Name, damage);
                    cardWeakest.MaxHP -= damage;
                    // step 3: check target status
                    if (cardWeakest.MaxHP < 0)
                    {
                        log.Write(BattleReport.DEAD, cardWeakest.Name);
                        combatTeam.Remove(cardWeakest);
                        if (combatTeam.Count <= 0)
                        {
                            log.Write(BattleReport.YOU_LOSE, family.Profile.Name);
                            isNotFinish = false;
                            break;
                        }
                        else
                        {
                            cardWeakest = null;
                        }
                    }
                }
            }            
            // report
            return log.Export();
        }
        private void Attack(CombatRate attacker, CombatRate target)
        {

        }
    }
}