using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Retribution
{
	public class BaseUtility
	{	
		public static float MultiLerp(float percent, params float[] floats)
		{
			float per = 1f / ((float)floats.Length - 1f);
			float total = per;
			int currentID = 0;
			while (percent / total > 1f && currentID < floats.Length - 2)
			{
				total += per;
				currentID++;
			}
			return MathHelper.Lerp(floats[currentID], floats[currentID + 1], (percent - per * (float)currentID) / per);
		}

		public static Vector2 MultiLerpVector(float percent, params Vector2[] vectors)
		{
			float per = 1f / ((float)vectors.Length - 1f);
			float total = per;
			int currentID = 0;
			while (percent / total > 1f && currentID < vectors.Length - 2)
			{
				total += per;
				currentID++;
			}
			return Vector2.Lerp(vectors[currentID], vectors[currentID + 1], (percent - per * (float)currentID) / per);
		}

		public static Color MultiLerpColor(float percent, params Color[] colors)
		{
			float per = 1f / ((float)colors.Length - 1f);
			float total = per;
			int currentID = 0;
			while (percent / total > 1f && currentID < colors.Length - 2)
			{
				total += per;
				currentID++;
			}
			return Color.Lerp(colors[currentID], colors[currentID + 1], (percent - per * (float)currentID) / per);
		}
	}
}
