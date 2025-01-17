﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zm.Levels;
using zm.Users;
using zm.Util;

namespace zm.Leaderboards
{
	public class LeaderboadrsUI : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private Dropdown dropdownLevels;

		[SerializeField]
		private VerticalLayoutGroup lstUsers;

		[SerializeField]
		private UserResultRenderer userRendererPrefab;

		/// <summary>
		/// Returns index of currently selected level.
		/// </summary>
		public int SelectedLevel
		{
			get { return dropdownLevels.value; }
		}

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Initialize view with all possible levels and set selected one.
		/// </summary>
		public void Initialize(List<Level> levels, List<UserResult> userResults)
		{
			dropdownLevels.ClearOptions();
			List<string> levelNames = new List<string>();
			foreach (Level level in levels)
			{
				levelNames.Add(level.Name);
			}
			dropdownLevels.AddOptions(levelNames);
			
			// select first level
            UpdateUsersList(userResults);
		}

		/// <summary>
		/// Updates list of users for selected level.
		/// </summary>
		/// <param name="level"></param>
		public void UpdateUsersList(List<UserResult> userResults)
		{
			userResults.Sort((x, y) => y.Points.CompareTo(x.Points));

			lstUsers.transform.Clear();
			int position = 1;
			foreach (UserResult user in userResults)
			{
				UserResultRenderer userRenderer = Instantiate(userRendererPrefab);
				userRenderer.Initialize(user, position++);
				userRenderer.transform.SetParent(lstUsers.transform, false);
			}
		}

		#endregion Public Methods
	}
}