using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public class Converter : RandoBunObject, IConverter
    {
        public byte[] ToBytes(object obj)
        {
            byte[] result;

            if (obj.GetType() == typeof(int)) result = BitConverter.GetBytes((int)obj);
            else if (obj.GetType() == typeof(long)) result = BitConverter.GetBytes((long)obj);
            else if (obj.GetType() == typeof(short)) result = BitConverter.GetBytes((short)obj);
            else if (obj.GetType() == typeof(float)) result = BitConverter.GetBytes((float)obj);
            else if (obj.GetType() == typeof(double)) result = BitConverter.GetBytes((double)obj);
            else throw new Exception(string.Format("Unsupported type {0} of value {1}", obj.GetType(), obj?.ToString()));

            return result;
        }

        public byte[] ToBytes(object obj, EntryValueType type)
        {
			byte[] result;
            switch(type)
            {
                case EntryValueType.HEX:
					// get int value from hex
                    int value = Convert.ToInt32(obj?.ToString(), 16);

					// convert int to bytes
                    result = ToBytes(value);
                    break;
				default:
					// convert with default function
					result = ToBytes(obj);
					break;
            }
            return result;
        }

        public object ToEntryValueType(string input, EntryValueType type)
        {
            switch(type)
			{

			}
        }
    }
}

/*
 	public static byte[] FROM_CUSTOM_TO_BYTES(object ir_value, EN_PKPL_WANTED_TYPE iv_wanted_type, int iv_length = 4) {
		byte[] lt_result = new byte[iv_length];
		byte[] lt_temp = new byte[iv_length];

		if (ir_value != null && iv_wanted_type != EN_PKPL_WANTED_TYPE.NONE) {
			try {
				switch (iv_wanted_type) {
					case EN_PKPL_WANTED_TYPE.INT:
						int lv_val_int = Convert.ToInt32(ir_value);
						lt_temp = BitConverter.GetBytes(lv_val_int);
						break;
					case EN_PKPL_WANTED_TYPE.DECIMAL:
						float lv_val_float = Convert.ToSingle(ir_value);
						lt_temp = BitConverter.GetBytes(lv_val_float);
						break;
					case EN_PKPL_WANTED_TYPE.HEX:
						int lv_val_hex = Convert.ToInt32(ir_value.ToString(), 16);
						lt_temp = BitConverter.GetBytes(lv_val_hex);
						break;
					default:
						CL_PKPL_CONSOLE.WRITE_LINE("FromCustomToByes: Conversion for WantedType *" + iv_wanted_type.ToString() + "* has not been defined");
						break;
				}
				//if length of new array is smaller/equal to the desired length, use it
				int lv_leftover = lt_temp.Length <= iv_length ? lt_temp.Length : iv_length;
				for (int i = 0; i < lv_leftover; i++) {
					lt_result[i] = lt_temp[i];
				}
			} catch (Exception lr_ex) {
				CL_PKPL_UI.SHOW_ERROR("Problem while converting " + ir_value.ToString() + " to byte array!" + lr_ex);
				lt_result = null;
			}
		}
		if (lt_result != null)
			Array.Reverse(lt_result);
		return lt_result;
	}
 */