using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nt_Cheater {
	public partial class FormMain : Form {

		/// <summary>
		/// 进程名
		/// </summary>
		private const string PROCESS_NAME = "Nightmare_trip";

		/// <summary>
		/// 游戏实例
		/// </summary>
		private readonly MyGame _myGame = new MyGame();

		/// <summary>
		/// 窗口主函数
		/// </summary>
		public FormMain() {
			if (!MyUtils.IsAdministrator()) {
				MessageBox.Show("没有以管理员身份启动，\n可能会造成修改进程失败！", "管理员权限", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				Environment.Exit(0);
				return;
			}

			InitializeComponent();

			ListboxDreampower.SelectedIndex = ListboxDreampower.Items.Count - 1;
			ListboxLife.SelectedIndex = ListboxLife.Items.Count - 1;
			ListboxBoom.SelectedIndex = ListboxBoom.Items.Count - 1;

			try {
				Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
			}
			catch (ArgumentException) { }
		}

		/// <summary>
		/// 主窗体加载后函数
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void Form1_Load(object sender, EventArgs e) {
			ButtonRefindGame_Click(null, null);
		}

		/// <summary>
		/// 按钮_重新寻找游戏
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonRefindGame_Click(object sender, EventArgs e) {
			MyUtils.FindProcess(PROCESS_NAME, CallBackFindProcessSuccess, CallBackFail);

			if (_myGame == null) {
				return;
			}

			if (_myGame.Quality == MyGame.QUALITY_SMOOTH) {
				CheckboxSmooth.Checked = true;
			}
		}

		/// <summary>
		/// 查找进程成功回调
		/// </summary>
		private void CallBackFindProcessSuccess() {
			MyUtils.GetPidByProcessName(PROCESS_NAME, CallBackGetProcessPidSuccess, CallBackFail);
		}
		/// <summary>
		/// 查找进程Pid成功回调
		/// </summary>
		/// <param name="pid"></param>
		private void CallBackGetProcessPidSuccess(int pid) {
			_myGame.pid = pid;

			MyUtils.GetProcessBaseAddr(PROCESS_NAME, CallBackGetProcessBaseAddrSuccess, CallBackFail);
		}
		/// <summary>
		/// 读取进程基地址成功回调
		/// </summary>
		/// <param name="baseAddr"></param>
		private void CallBackGetProcessBaseAddrSuccess(IntPtr baseAddr) {
			_myGame.baseAddr = baseAddr;
			_myGame.Init();

			MyToolStripStatusLabel.Text = "进程Pid：" + _myGame.pid + "，当前难度：" + _myGame.Difficulty;
			MyTimer.Enabled = true;

			MyUtils.SetAllControlEnable(Controls, true);
		}
		/// <summary>
		/// 失败回调
		/// </summary>
		private void CallBackFail() {
			MyToolStripStatusLabel.Text = "打开游戏失败：" + PROCESS_NAME;
			MyTimer.Enabled = false;

			MyUtils.SetAllControlEnable(Controls, false);
		}



		/// <summary>
		/// 按钮_得分
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonScore_Click(object sender, EventArgs e) {
			if (!int.TryParse(TextboxScore.Text, out int score)) {
				score = 0;
			}

			_myGame.WriteMemory(MyAddress.SCORE, score);
		}
		/// <summary>
		/// 按钮_得分率
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonScorerate_Click(object sender, EventArgs e) {
			if (!int.TryParse(TextboxScorerate.Text, out int scoreRate)) {
				scoreRate = 0;
			}

			// 需要除以10
			scoreRate /= 10;

			_myGame.WriteMemory(MyAddress.SCORERATE, scoreRate);
		}
		/// <summary>
		/// 按钮_梦想力
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonDreampower_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxDreampower.SelectedItem, out int dreamPower)) {
				dreamPower = 0;
			}

			_myGame.WriteMemory(MyAddress.DREAMPOWER, dreamPower);
		}
		/// <summary>
		/// 按钮_残机
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonLife_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxLife.SelectedItem, out int life)) {
				life = 1;
			}

			_myGame.WriteMemory(MyAddress.LIFE, life);
		}
		/// <summary>
		/// 按钮_BOOM
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void ButtonBoom_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxBoom.SelectedItem, out int boom)) {
				boom = 1;
			}

			_myGame.WriteMemory(MyAddress.BOOM, boom);
		}




		/// <summary>
		/// 复选框_不消耗梦想力
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void CheckboxDreampower_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			// 梦想力真实地址
			int dreamPowerRealAddr = _myGame.GetRealAddress(MyAddress.DREAMPOWER);

			// 源代码  ：C7 05 | ~~ ~~ ~~ ~~ | 00 00 | 00 00
			// 逆序后  ：05 C7 | ~~ ~~ ~~ ~~ | 00 00 | 00 00
			int[] lpBuffer = new int[] { 0x05C7, dreamPowerRealAddr, 0x0000, 0x0000 };
			int[] nSize = new int[] { 2, 4, 2, 2 };

			if (self.Checked) {
				// 目标代码：90 90 | 90 90 | 90 90 | 90 90 | 90 90
				// 逆序目标：90 90 | 90 90 | 90 90 | 90 90 | 90 90
				lpBuffer = new int[] { 0x9090, 0x9090, 0x9090, 0x9090, 0x9090 };
				nSize = new int[] { 2, 2, 2, 2, 2 };
			}

			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_DREAMPOWER,
				lpBuffer,
				nSize
			);
		}
		/// <summary>
		/// 复选框_不消耗残机
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void CheckboxLife_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			// 残机真实内存地址
			int lifeRealAddr = _myGame.GetRealAddress(MyAddress.LIFE);

			// 源代码  ：FF 0D | ~~ ~~ ~~ ~~ ~~
			// 逆序后  ：0D FF | ~~ ~~ ~~ ~~ ~~
			int[] lpBuffer = new int[] { 0x0DFF, lifeRealAddr };
			int[] nSize = new int[] { 2, 4 };

			if (self.Checked) {
				// 目标代码：90 90 | 90 90 | 90 90
				// 逆序目标：90 90 | 90 90 | 90 90
				lpBuffer = new int[] { 0x9090, 0x9090, 0x9090 };
				nSize = new int[] { 2, 2, 2 };
			}

			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_LIFE,
				lpBuffer,
				nSize
			);
		}
		/// <summary>
		/// 复选框_不消耗BOOM
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void CheckboxBoom_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			int[] lpBuffer =
				self.Checked ?
				// 目标代码：90
				new int[] { 0x90 } :
				// 源代码  ：4E
				new int[] { 0x4E };
			
			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_BOOM,
				lpBuffer,
				new int[] { 1 }
			);
		}




		/// <summary>
		/// 复选框_修改画质
		/// </summary>
		/// <param name="sender">发送器</param>
		/// <param name="e">事件参数</param>
		private void CheckboxSmooth_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			_myGame.Quality = self.Checked ? MyGame.QUALITY_SMOOTH : MyGame.QUALITY_NO_SMOOTH;
		}

		private void MyTimer_Tick(object sender, EventArgs e) {
			ButtonRefindGame_Click(null, null);
		}
	}
}
