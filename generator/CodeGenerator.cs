// GtkSharp.Generation.CodeGenerator.cs - The main code generation engine.
//
// Author: Mike Kestner <mkestner@speakeasy.net>
//
// (c) 2001 Mike Kestner

namespace GtkSharp.Generation {

	using System;
	using System.Collections;
	using System.Xml;

	public class CodeGenerator  {

		public static int Main (string[] args)
		{
			if (args.Length != 1) {
				Console.WriteLine ("Usage: codegen <filename>");
				return 0;
			}

			Parser p = new Parser (args[0]);
			p.Parse ();
			Console.WriteLine (SymbolTable.Count + " types parsed.");
			
			foreach (IGeneratable gen in SymbolTable.Generatables) {
				gen.Generate ();
			}

			ObjectGen.GenerateMapper ();

			Statistics.Report();
			return 0;
		}

	}
}
