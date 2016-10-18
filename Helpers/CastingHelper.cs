using GlobalDevelopment.Packages;
using GlobalDevelopment.Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using GlobalDevelopment.Interfaces;

namespace GlobalDevelopment.Helpers
{
    public static class CastingHelper
    {
        public static bool IsInt(string number)
        {
            int num;
            if (int.TryParse(number, out num))
            {
                return true;
            }
            return false;
        }
        public static byte[] ObjectToByteArray(object obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    try
                    {
                        bf.Serialize(ms, obj);
                        return ms.ToArray();
                    }
                    catch (Exception er)
                    {
                        IErrorPackage error = new ErrorPackage("GeneralHelper | ObjectToByteArray | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                        return ObjectToByteArray(error);
                    }
                }
            }
            catch (Exception er)
            {
                IErrorPackage error = new ErrorPackage("GeneralHelper | ObjectToByteArray | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                return ObjectToByteArray(error);
            }
        }
        public static byte[] ObjectListToByteArray(List<object> objs)
        {
            List<byte[]> dataList = new List<byte[]>();
            try
            {
                foreach (object obj in objs)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (var ms = new MemoryStream())
                    {
                        try
                        {
                            bf.Serialize(ms, obj);
                            dataList.Add(ms.ToArray());
                        }
                        catch (Exception er)
                        {
                            IErrorPackage error = new ErrorPackage("GenneralHelper | ObjectListToByteArray | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                            dataList.Add(ObjectToByteArray(error));
                        }
                    }
                }
            }
            catch (Exception er)
            {
                IErrorPackage error = new ErrorPackage("GeneralHelper | ObjectListToByteArray | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                dataList.Add(ObjectToByteArray(error));
            }
            return ObjectToByteArray(dataList);
        }
        public static object ByteArrayToObject(byte[] data)
        {
            try
            {
                object obj;
                using (var memStream = new MemoryStream())
                {
                    try
                    {
                        memStream.Write(data, 0, data.Length);
                        memStream.Seek(0, SeekOrigin.Begin);
                    }
                    catch (Exception er)
                    {
                        return new ErrorPackage("GeneralHelper | ByteArrayToObject | General Error: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                    }
                    finally
                    {
                        var binForm = new BinaryFormatter();
                        obj = binForm.Deserialize(memStream);
                        memStream.Dispose();
                    }
                }
                return obj;
            }
            catch (Exception er)
            {
                return new ErrorPackage("GeneralHelper | ByteArrayToObject | General Error: " + er.Message, (int)PacketHandler.Errors.BadRequest);
            }
        }
        public static List<byte[]> ObjectListToByteArrayList(List<object> objs)
        {
            List<byte[]> byteData = new List<byte[]>();
            byte[] data = ObjectListToByteArray(objs);
            using (MemoryStream memStream = new MemoryStream())
            {
                try
                {
                    memStream.Write(data, 0, data.Length);
                    memStream.Seek(0, SeekOrigin.Begin);

                    var binForm = new BinaryFormatter();
                    byteData = binForm.Deserialize(memStream) as List<byte[]>;
                }
                catch (Exception er)
                {
                    IErrorPackage error = new ErrorPackage("GeneralHelper | ObjectListToByteArrayList | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                    byteData.Add(ObjectToByteArray(error));
                }
            }
            return byteData;
        }
        public static List<object> ByteArrayToObjectList(byte[] data)
        {
            List<object> objectList = new List<object>();
            try
            {

                using (MemoryStream memStream = new MemoryStream())
                {
                    try
                    {
                        memStream.Write(data, 0, data.Length);
                        memStream.Seek(0, SeekOrigin.Begin);

                        var binForm = new BinaryFormatter();
                        var byteData = binForm.Deserialize(memStream);
                        foreach (byte[] byteD in byteData as List<byte[]>)
                        {
                            var ob = ByteArrayToObject(byteD);
                            objectList.Add(ob);
                        }
                        memStream.Dispose();
                    }
                    catch (Exception er)
                    {
                        IErrorPackage error = new ErrorPackage("GeneralHelper | ByteArrayToObjectList | General Exception: " + er.Message, (int)PacketHandler.Errors.BadRequest);
                        objectList.Add(error);
                    }
                }
            }
            catch (Exception er)
            {
                IErrorPackage error = new ErrorPackage(er.Message, 400);
                objectList.Add(error);
            }
            return objectList;
        }
        public static long Imagesize(Image image)
        {
            long imageSize = 0;
            using (var memStream = new MemoryStream())
            {
                image.Save(memStream, image.RawFormat); // Saves image to the stream in it's format
                imageSize = memStream.Length;
            }
            return imageSize;
        }
        public static int ObjectSize(object obj)
        {
            return ObjectToByteArray(obj).Length;
        }
    }
}
