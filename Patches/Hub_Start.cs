using System.Collections.Immutable;
using System.Reflection;
using Bifrost.LocalizationData;
using HarmonyLib;
using ItemsAPI.Helpers;

namespace CrowbarForAll.Patches
{
    [HarmonyPatch(typeof(Hub), "Start")]
    internal static class Hub_Start
    {
        private static void Postfix()
        {
            DataManager dataManager = ReflectionTools.GetFieldOrProperty<DataManager>(Hub.s, "<dataman>k__BackingField") ?? throw new NullReferenceException("DataManager not ready.");
            LocalizationData_MasterData vendingMachineTooltipLocalizationData = new LocalizationData_MasterData()
            {
                key = "STRING_CROWBAR_VENDING_MACHINE_TOOLTIP",

                ar = "إذا كان بإمكانك الدفاع عن نفسك بها، فيمكنك القتال بها أيضاً!",
                de = "Wenn man sich damit verteidigen kann, kann man auch damit kämpfen!",
                en = "If you can defend yourself with it, you can fight with it too!",
                es = "¡Si puedes defenderte con ella, también puedes pelear con ella!",
                fr = "Si on peut se défendre avec, c'est qu'on peut aussi se battre avec !",
                it = "Se puoi difenderti con essa, puoi anche combattere con essa!",
                ja = "身を守れるなら、戦うことだってできる！",
                ko = "이걸로 자신을 지킬 수 있다면, 싸울 수도 있다!",
                pl = "Jeśli możesz się tym bronić, możesz też tym walczyć!",
                pt_br = "Se dá para se defender com isso, também dá para lutar!",
                ru = "Если этим можно защищаться, значит этим можно и драться!",
                th = "ถ้าใช้ป้องกันตัวได้ ก็ใช้สู้ได้เหมือนกัน!",
                tr = "Kendini bununla savunabiliyorsan, bununla dövüşebilirsin de!",
                uk = "Якщо цим можна захищатися, то цим можна й битися!",
                vi = "Nếu có thể dùng nó để tự vệ, thì cũng có thể dùng nó để chiến đấu!",
                zh_cn = "既然能用它自卫，那当然也能用它来战斗！",
                zh_tw = "既然能用它自衛，那當然也能拿來戰鬥！"
            };
            ImmutableDictionary<string, LocalizationData_MasterData> localizationUpdated = dataManager.ExcelDataManager.LocalizationDict
                .Remove(vendingMachineTooltipLocalizationData.key)
                .Add(
                    vendingMachineTooltipLocalizationData.key,
                    vendingMachineTooltipLocalizationData
                );
            PropertyInfo localizationProp = typeof(ExcelDataManager).GetProperty(
                "LocalizationDict",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            ) ?? throw new Exception("Could not find ExcelDataManager.LocalizationDict property.");
            localizationProp.SetValue(dataManager.ExcelDataManager, localizationUpdated);

            ReflectionTools.SetFieldOrProperty(dataManager.ExcelDataManager.ItemInfoDict[2900], "VendingMachineTooltip", vendingMachineTooltipLocalizationData.key);
        }
    }
}