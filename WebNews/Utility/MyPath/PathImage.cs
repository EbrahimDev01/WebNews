using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace WebNews.Utility.MyPath
{
    public static class PathImage
    {

        /// <summary>
        /// return path image full 
        /// </summary>
        /// <param name="name">name image for get full paht</param>
        /// <returns>full paht image</returns>
        public static async Task<string> GetFullPathImage(string name)
        {
            if (name == "" || name == null)
                return "";

            return await Task.Run(() =>
            {
                string imgPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                "wwwrot",
                    "ImagesNews",
                    name);

                if (ImageIsExists(pathfull: imgPath))
                    return "";

                return imgPath;
            });
        }

        public static async Task<string> GetPathImage(string name)
        {
            if (name == "" || name == null)
                return "";

            return await Task.Run(() =>
            {
                string imgPath = Path.Combine(
                    "/ImagesNews",
                    name);

                if (ImageIsExists(pathfull: imgPath))
                    return "";

                return imgPath;
            });
        }

        public static bool ImageIsExists(string pathfull = null, string name = null)
        {
            string imgPath = pathfull;

            if (name != null)
            {
                imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                       "wwwrot",
                       "ImagesNews",
                       name);
            }

            return File.Exists(imgPath);
        }
    }
}
