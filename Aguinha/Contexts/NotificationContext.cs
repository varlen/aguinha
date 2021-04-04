using System;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Aguinha.Contexts
{
    public class NotificationContext
    {
        private ToastContentBuilder CreateNotification()
        {
            return new ToastContentBuilder()
                .AddText("Está na hora de beber água! 🥤")
                .AddText("É importante manter-se hidratado ao longo do dia. Aproveite a pausa para alongar e encher o copo!")
                .AddButton(new ToastButton()
                    .SetContent("Já me hidratei!")
                );
        }

        /// <summary>
        /// Immediately display notification
        /// </summary>
        public void ShowNotification()
        {
            CreateNotification().Show();
        }

        /// <summary>
        /// Display notification at the given moment.
        /// Notifications will be sent up to 5 minutes after the scheduled time.
        /// They will be dropped if not possible to send within this window (e.g.: System is hibernating)
        /// </summary>
        public void ScheduleNotification(DateTime notifyAt)
        {
            CreateNotification().Schedule(notifyAt);
        }
    }
}
