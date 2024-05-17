﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PWIWEBAPI.DataContext;
using PWIWEBAPI.Services;
using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace PWIWEBAPI.Models
{
	public class GamesysModel
	{
		public int? TitleIndex { get; set; }
		public string? Title { get; set; }
		public List<Types>? Types { get; set; }

		public void OnInit()
		{
			for (int i = 0; i < Types.Count; i++)
			{
				Types[i].OnInit();

			}
		}
		public bool OnTypes()
		{
			//for (int i = 0; i < Types.Count; i++)
			//{
			//	if (Types[i].OnTypes())
			//	{
			//		return true;
			//	}

			//}
			return false;
		}

		public bool ActionValues(Actions actions, int ik, object obj)
		{
			if (Types != null)
			{
				switch (actions)
				{
					case Actions.INSERT:
						((InterString)Types[ik].Value).Value = ((InterString)Types[ik].Value).Value.GetType() == typeof(object[])?
							Extencions.addItensArray(((object[])((InterString)Types[ik].Value).Value), obj) : obj;
						break;
					case Actions.UPDATE:
						break;
					case Actions.DELETE:
						break;
					default:
						return false;
						break;
				}

			}

			return false;
			//gamesysModels[it].Types.Add(new Types { Key = temps[0], KeyIndex = xt, Value = tempValue});
		}


	}
	public class Types
	{
		public int? KeyIndex { get; set; }
		public string? Key { get; set; }
		public object? Value { get; set; }
		public object? IndexValue { get; set; }

		public void OnInit()
		{

			if (Value is not null)
			{
				//if (Value.GetType() == typeof(object[]))
				//{
				//	TypeValue = null;

				//	object[] array = (object[])Value;
				//	string tempAr = "";

				//	for (int i = 0; i < array.Length; i++)
				//	{
				//		if (int.TryParse(array[i].ToString(), out int numero))
				//		{
				//			tempAr += "int;";
				//		}
				//		else if (float.TryParse(array[i].ToString(), out float numeroF))
				//		{
				//			if (Regex.Matches(array[i].ToString(), ".").Count >= 3)
				//			{
				//				tempAr += "string;";
				//			}
				//			else
				//			{
				//				tempAr += "float;";
				//			}

				//		}
				//		else if (bool.TryParse(array[i].ToString(), out bool result))
				//		{
				//			tempAr += "bool;";
				//		}
				//		else
				//		{
				//			if (array[i].ToString().EndsWith("f"))
				//			{
				//				tempAr += "float;";
				//			}
				//			else
				//			{
				//				tempAr += "string;";
				//			}
				//		}
				//	}
				//	TypeValue = (object[])tempAr.Split(";").Where(x => x != "").ToArray();



				//}
				//else
				//{
				//	if (int.TryParse(Value.ToString(), out int numero))
				//	{
				//		TypeValue = "int";
				//	}
				//	else if (float.TryParse(Value.ToString(), out float numeroF))
				//	{
				//		if (Regex.Matches(Value.ToString(), ".").Count >= 3)
				//		{
				//			TypeValue = "string";
				//		}
				//		else
				//		{
				//			TypeValue = "float";
				//		}
				//	}
				//	else if (bool.TryParse(Value.ToString(), out bool result))
				//	{
				//		TypeValue = "bool";
				//	}
				//	else
				//	{
				//		if (Value.ToString().EndsWith("f"))
				//		{
				//			TypeValue = "float";
				//		}
				//		else
				//		{
				//			TypeValue = "string";
				//		}

				//	}
				//}
				SetIndex();

			}
		}
		private void SetIndex()
		{
			if (Value is not null)
			{
				if (Value.GetType() == typeof(object[]))
				{
					object[] array = (object[])Value;
					IndexValue = new object[array.Length];
					for (int i = 0; i < ((object[])Value).Length; i++)
					{
						((object[])IndexValue)[i] = i;
					}
				}
				else
				{
					IndexValue = 0;
				}

			}
		}
		public bool OnTypes()
		{

			if (Value is not null)
			{
				try
				{
					if (Value.GetType() == typeof(object[]))
					{
						object[] arrayValue = (object[])Value;
						object[] arrayType = (object[])Value;

						for (int i = 0; i < arrayValue.Length; i++)
						{
							switch (arrayType[i])
							{
								case "int":
									arrayValue[i] = Convert.ToInt32(arrayValue[i]);
									break;
								case "float":
									string temp = ((string)arrayValue[i]).ToUpper().Replace("F", "");
									arrayValue[i] = $"{temp}f";
									break;
								default:
									break;
							}

						}
					}
					else
					{
						switch (Value.ToString())
						{
							case "int":
								Value = (object)Convert.ToInt32(Value.ToString());
								break;
							case "float":
								string temp = Value.ToString().ToUpper().Replace("F", "");
								Value = $"{temp}f";
								break;
							default:
								break;
						}
					}
					return false;
				}
				catch (Exception ex)
				{
					Logger.Loggers.LogWriteLog(PWIWEBAPI.Logger.TypeLog.WARNING, PWIWEBAPI.Logger.TypeActionLog.EXECUTE, PWIWEBAPI.Logger.TypePostionLog.ERROR, "OnTypes()", "GamesysModel", ex.Message);
					return true;
				}

			}
			return true;
		}

	}
	public class InterString
	{
		public object? Value { get; set; }
		public string? StartString { get; set; }
		public string? JoinString { get; set; }
		public string? EndString { get; set; }

	}

	public class ListModel
	{
		public int Index { get; set; }
		public string Value { get; set; }
	}

}
