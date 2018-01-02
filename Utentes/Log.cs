﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utentes
{
    public static class Log
    {
        private static List<string> log = new List<string>();
        public static void Info(string mensagem)
        {
            string msg = DateTime.Now.ToString() + " [INFO]: " + mensagem;
            log.Add(msg);
            return;
        }

        public static void Aviso(string mensagem)
        {
            string msg = DateTime.Now.ToString() + " [AVISO]: " + mensagem;
            log.Add(msg);
            return;
        }

        public static void Erro(string mensagem)
        {
            string msg = DateTime.Now.ToString() + " [ERRO]: " + mensagem;
            log.Add(msg);
            return;
        }

        public static void PrintLog()
        {
            foreach (var item in log)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Adiciona ao ficheiro de texto das logs a linha
        /// </summary>
        /// <param name="mensagem"></param>
        /// <returns></returns>
        private static bool Append(string mensagem)
        {
            return true;
        }
    }
}