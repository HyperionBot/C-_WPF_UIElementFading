using System.Threading.Tasks;
using System.Windows;
    
    public class UIElementFade
    {
        //*********************************************************************************************************************************************************
        /// <summary>
        /// Fade control for an UIElement
        /// </summary>
        /// <param The target="target"></param>
        /// <param The time for the fade in/out to occur in="FadeTime"></param>
        /// <param The time before the fade in should occur="DelayBeforeFade"></param>
        /// <param The time before the fade out should occur="DelayBeforeOutFade"></param>
        public static async Task<bool> FadeIO(UIElement target, int FadeTime = 100, int DelayBeforeFade = 5000, int DelayBeforeOutFade = 10000)
        {
            double OpacTick = 0; //The "counter" for the while loops.
            double FadeAmount = ((double)1 / FadeTime); //Calculates the required opacity increment for the fade to happen in the specified time.
            await Task.Delay(DelayBeforeFade); //Holds until the required delay before the fade has been reached.
            do
            {
                target.Opacity = 0 + OpacTick; //Alters the target's opacity based on the current loop cylce.
                OpacTick += FadeAmount; //Alters the counter by the pre calculated alteration amount.
                await Task.Delay(1); //Halts the loop

            } while (OpacTick <= 1); //Loops finished when the target's opacity is 1.
            OpacTick = 0; //Resets the loop counter.
            await Task.Delay(DelayBeforeOutFade); //Holds until the required delay before the fade out has been reached
            do
            {
                target.Opacity = 1 - OpacTick; //Alters the target's opacity based on the current loop cylce.
                OpacTick += FadeAmount; //Alters the counter by the pre calculated alteration amount.
                await Task.Delay(1); //Halts the loop

            } while (OpacTick <= 1); //Loops finished when the target's opacity is 0 and the counter is therefor 1.
            target.Opacity = 0;
            return true;
        }
        //*********************************************************************************************************************************************************
    }
