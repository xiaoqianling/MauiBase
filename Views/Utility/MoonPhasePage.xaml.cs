using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBase.Data;

namespace MauiBase.Views
{
    partial class MoonPhasePage:ContentPage
    {
        public MoonPhasePage()
        {
            InitializeComponent();
            InitializeUI();
        }
        void InitializeUI()
        {
            var phase = MoonPhaseCalculator.GetPhase(DateTime.Now);

            //lblDate.Text = DateTime.Now.ToString();
            lblMoonPhaseIcon.Text = moonPhaseEmojis[phase];
            lblMoonPhaseText.Text = moonPhaseChinese[phase];

            SetMoonPhaseLabels(lblPhaseIcon1, lblPhaseText1, 1);
            SetMoonPhaseLabels(lblPhaseIcon2, lblPhaseText2, 2);
            SetMoonPhaseLabels(lblPhaseIcon3, lblPhaseText3, 3);
            SetMoonPhaseLabels(lblPhaseIcon4, lblPhaseText4, 4);
        }

        void SetMoonPhaseLabels(Label lblIcon, Label lblText, int dayOffset)
        {
            var phase = MoonPhaseCalculator.GetPhase(DateTime.Now.AddDays(dayOffset));
            lblIcon.Text = moonPhaseEmojis[phase];
            lblText.Text = DateTime.Now.AddDays(dayOffset).DayOfWeek.ToString();
        }

        static Dictionary<MoonPhaseCalculator.Phase, string> moonPhaseEmojis = new Dictionary<MoonPhaseCalculator.Phase, string>
        {
            { MoonPhaseCalculator.Phase.New, "🌑" },
            { MoonPhaseCalculator.Phase.WaxingCrescent, "🌒" },
            { MoonPhaseCalculator.Phase.FirstQuarter, "🌓" },
            { MoonPhaseCalculator.Phase.WaxingGibbous, "🌔" },
            { MoonPhaseCalculator.Phase.Full, "🌕" },
            { MoonPhaseCalculator.Phase.WaningGibbous, "🌖" },
            { MoonPhaseCalculator.Phase.LastQuarter, "🌗" },
            { MoonPhaseCalculator.Phase.WaningCrescent, "🌘" },
        };

        static Dictionary<MoonPhaseCalculator.Phase, string> moonPhaseChinese = new Dictionary<MoonPhaseCalculator.Phase, string>
        {
            { MoonPhaseCalculator.Phase.New, "新月" },
            { MoonPhaseCalculator.Phase.WaxingCrescent, "峨眉月" },
            { MoonPhaseCalculator.Phase.FirstQuarter, "上弦月" },
            { MoonPhaseCalculator.Phase.WaxingGibbous, "盈凸月" },
            { MoonPhaseCalculator.Phase.Full, "满月" },
            { MoonPhaseCalculator.Phase.WaningGibbous, "亏凸月" },
            { MoonPhaseCalculator.Phase.LastQuarter, "下弦月" },
            { MoonPhaseCalculator.Phase.WaningCrescent, "残月" },
        };
    }
}
