// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using osu.Framework.Android;
using osu.Game;
using osu.Game.Rulesets;

namespace osu.Android
{
    [Activity(Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.SensorLandscape, SupportsPictureInPicture = false, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize, HardwareAccelerated = true)]
    public class OsuGameActivity : AndroidGameActivity
    {
        static OsuGameActivity()
        {
            // When a ruleset assembly is missing, the exception will be thrown during JIT-ing the lambda method
            // and will be handled in LoadRulesetFromType().
            RulesetStore.LoadRulesetFromType(() => typeof(Game.Rulesets.Osu.OsuRuleset), "osu");
            RulesetStore.LoadRulesetFromType(() => typeof(Game.Rulesets.Taiko.TaikoRuleset), "taiko");
            RulesetStore.LoadRulesetFromType(() => typeof(Game.Rulesets.Mania.ManiaRuleset), "mania");
            RulesetStore.LoadRulesetFromType(() => typeof(Game.Rulesets.Catch.CatchRuleset), "catch");
        }

        protected override Framework.Game CreateGame()
            => new OsuGame();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);
        }
    }
}
