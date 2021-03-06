﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Parsing;
using CommandLine.Text;
namespace UnityAssetTool.Command
{
    public class UnityAssetTools
    {
        [VerbOption("ttdb-learn", HelpText = "learn typetree form asset bundle or asset file.")]
        public TypeTreeDataBaseLearn TypeTreeDatabase_Learn { get; set; }

        [VerbOption("ttdb-show",HelpText ="show typetree info")]
        public TypeTreeDataBaseShow TypeTreeDatabase_show { get; set; }

        [VerbOption("asset-unpack",HelpText ="extract asset objects.")]
        public AssetUnpackCommand asset_unpack { get; set; }

        [VerbOption("asset-sizeinfo", HelpText = "display assets size info.")]
        public AssetSizeInfoCommand asset_sizeinfo { get; set; }

        [VerbOption("apk-unpack", HelpText = "extract asset objects form apk file")]
        public APKUnpackCommand apk_unpack { get; set; }
        //
        // Marking a property of type IParserState with ParserStateAttribute allows you to
        // receive an instance of ParserState (that contains a IList<ParsingError>).
        // This is equivalent from inheriting from CommandLineOptionsBase (of previous versions)
        // with the advantage to not propagating a type of the library.
        //
        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }

        public void Run(string[] args)
        {
            bool error = true;
            if (args.Length > 1) {
                Parser.Default.ParseArguments(args, this, (cmdName, cmdIns) => {
                    if (cmdIns != null) {
                        Command cmd = cmdIns as Command;
                        if (cmd != null) {
                            error = false;
                            cmd.run();
                        }
                    }
                });

            }
            if (error) {
                Console.WriteLine(GetUsage());
            }
        }
    }
}
