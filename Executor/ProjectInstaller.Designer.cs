namespace Executor
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
            this.ServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SHExecutorInstall = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceProcessInstaller
            // 
            this.ServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.NetworkService;
            this.ServiceProcessInstaller.Password = null;
            this.ServiceProcessInstaller.Username = null;
            // 
            // SHExecutorInstall
            // 
            this.SHExecutorInstall.Description = "Processo executor do modulo integrador Santa Helena, realiza buscas de informaçõe" +
    "s em outros sistemas para serem processadas pelo serviço SH-Consumidor";
            this.SHExecutorInstall.DisplayName = "SH-Integrador-Executor";
            this.SHExecutorInstall.ServiceName = "SH-Integrador-Executor";
            this.SHExecutorInstall.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ServiceProcessInstaller,
            this.SHExecutorInstall});

		}

		#endregion

        private System.ServiceProcess.ServiceProcessInstaller ServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SHExecutorInstall;
	}
}