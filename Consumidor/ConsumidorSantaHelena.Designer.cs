using System.Timers;
namespace Consumidor
{
    partial class ConsumidorSantaHelena
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Timers.Timer timer;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // "FC.Integrador.SantaHelena.Consumidor"
            // 
            this.ServiceName = "FC.Integrador.SantaHelena.Consumidor";

            this.timer = new System.Timers.Timer();

            this.timer.Enabled = true;
            this.timer.Interval = this.ServicoTempo;
            this.timer.Elapsed += new ElapsedEventHandler(this.timer_Tick);
        }

        #endregion
    }
}
