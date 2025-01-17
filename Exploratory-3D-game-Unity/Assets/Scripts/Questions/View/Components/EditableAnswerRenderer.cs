﻿using UnityEngine;
using UnityEngine.UI;

namespace zm.Questioning
{
    public class EditableAnswerRenderer : AnswerRendererBase
	{
		#region Public Methods

		/// <summary>
		/// Records all changes from the view to Answer
		/// </summary>
		public void RecordAnswer()
		{
			answer.Text = inputAnswerText.text;
			answer.IsCorrect = toggleIsCorrect.isOn;
		}

		public void SetToggleGroup(ToggleGroup group)
		{
			toggleIsCorrect.group = group;
		}

		#endregion Public Methods

		#region Fields and Properties

		public override Answer Answer
		{
			set
			{
				answer = value;
				inputAnswerText.text = value.Text;
				toggleIsCorrect.isOn = value.IsCorrect;
			}

			get { return answer; }
		}

		[SerializeField]
		private InputField inputAnswerText;

		[SerializeField]
		private Toggle toggleIsCorrect;

		#endregion Fields and Properties
	}
}