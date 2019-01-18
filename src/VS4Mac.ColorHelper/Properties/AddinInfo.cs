using System;
using System.Runtime.InteropServices;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
    "ColorHelper",
    Namespace = "MonoDevelop",
    Version = "0.1",
    Category = "IDE extensions"
)]

[assembly: AddinName("Color Helper")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("Color Helper is a Visual Studio for macOS addin to add some color helper tools.")]
[assembly: AddinAuthor("Javier Suárez Ruiz")]
[assembly: AddinUrl("https://github.com/jsuarezruiz/VS4Mac-ColorHelper")]

[assembly: CLSCompliant(false)]
[assembly: ComVisible(false)]