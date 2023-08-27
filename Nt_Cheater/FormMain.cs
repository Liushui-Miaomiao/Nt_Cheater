using System;
using System.Drawing;
using System.Windows.Forms;

namespace Nt_Cheater {
	public partial class FormMain : Form {

		/// <summary>
		/// 进程名
		/// </summary>
		private const string PROCESS_NAME = "Nightmare trip";

		/// <summary>
		/// 游戏实例
		/// </summary>
		private MyGame _myGame = new MyGame();

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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e) {
			ButtonRefindGame_Click(null, null);
		}

		/// <summary>
		/// 按钮_重新寻找游戏
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonScore_Click(object sender, EventArgs e) {
			if (!int.TryParse(TextboxScore.Text, out int score)) {
				score = 0;
			}

			_myGame.WriteMemory(MyAddress.SCORE, score);
		}
		/// <summary>
		/// 按钮_得分率
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonScorerate_Click(object sender, EventArgs e) {
			if (!int.TryParse(TextboxScorerate.Text, out int scoreRate)) {
				scoreRate = 0;
			}

			// 需要除以10
			scoreRate /= 10;

			_myGame.WriteMemory(MyAddress.SCORERATE, scoreRate);
		}
		/// <summary>
		/// 按钮梦想力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonDreampower_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxDreampower.SelectedItem, out int dreamPower)) {
				dreamPower = 0;
			}

			_myGame.WriteMemory(MyAddress.DREAMPOWER, dreamPower);
		}
		/// <summary>
		/// 按钮_残机
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonLife_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxLife.SelectedItem, out int life)) {
				life = 1;
			}

			_myGame.WriteMemory(MyAddress.LIFE, life);
		}
		/// <summary>
		/// 按钮_BOOM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonBoom_Click(object sender, EventArgs e) {
			if (!int.TryParse((string)ListboxBoom.SelectedItem, out int boom)) {
				boom = 1;
			}

			_myGame.WriteMemory(MyAddress.BOOM, boom);
		}




		/// <summary>
		/// 复选框_不消耗梦想力
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckboxDreampower_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			if (self.Checked) {
				// 目标代码：90 90 90 | 90 90 90 | 90 90 90 | 90 (00) (00)
				// 逆序目标：90 90 90 | 90 90 90 | 90 90 90 | (00) (00) 90
				_myGame.WriteMemoryArray(
					MyAddress.NOUSE_DREAMPOWER,
					new int[] { 0x909090, 0x909090, 0x909090, 0x000090 },
					new int[] { 3, 3, 3, 1 }
				);

				return;
			}

			// 源代码  ：C7 05 54 | 92 45 01 | 00 00 00 | 00 (00) (00)
			// 逆序后  ：54 05 C7 | 01 45 92 | 00 00 00 | (00) (00) 00
			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_DREAMPOWER,
				new int[] { 0x5405C7, 0x014592, 0x000000, 0x000000 },
				new int[] { 3, 3, 3, 1 }
			);
		}
		/// <summary>
		/// 复选框_不消耗残机
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckboxLife_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			if (self.Checked) {
				// 目标代码：90 90 90 | 90 90 90
				// 逆序目标：90 90 90 | 90 90 90
				_myGame.WriteMemoryArray(
					MyAddress.NOUSE_LIFE,
					new int[] { 0x909090, 0x909090 },
					new int[] { 3, 3 }
				);

				return;
			}

			// 源代码  ：FF 0D 30 | 8D 45 01
			// 逆序后  ：30 0D FF | 01 45 8D
			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_LIFE,
				new int[] { 0x300DFF, 0x01458D },
				new int[] { 3, 3 }
			);
		}
		/// <summary>
		/// 复选框_不消耗BOOM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckboxBoom_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			if (self.Checked) {
				// 目标代码：90 90 90 | 90 90 90
				// 逆序目标：90 90 90 | 90 90 90
				_myGame.WriteMemoryArray(
					MyAddress.NOUSE_BOOM,
					new int[] { 0x909090, 0x909090 },
					new int[] { 3, 3 }
				);

				return;
			}

			// 源代码  ：89 35 38 | 8D 45 01
			// 逆序后  ：38 35 89 | 01 45 8D
			_myGame.WriteMemoryArray(
				MyAddress.NOUSE_BOOM,
				new int[] { 0x383589, 0x01458D },
				new int[] { 3, 3 }
			);
		}




		/// <summary>
		/// 复选框_修改画质
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckboxSmooth_CheckedChanged(object sender, EventArgs e) {
			CheckBox self = (CheckBox)sender;

			_myGame.Quality = self.Checked ? MyGame.QUALITY_SMOOTH : MyGame.QUALITY_NO_SMOOTH;
		}

		private void MyTimer_Tick(object sender, EventArgs e) {
			ButtonRefindGame_Click(null, null);
		}
	}
}
