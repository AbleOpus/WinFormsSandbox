# WinFormsSandbox
This project was sent to me by a man named Nissim Trabelsy. He told me I could do whatever with it. So I did. Some of his reflection work remains mostly untouched, everything else not so much. I decided to refactor his code base and add features just for the heck of it. This project serves little purpose at this point, considering how powerful and intuitive Visual Studio has become.
The WinFormsSandbox allows one to dynamically work with instance Types in a WinForms environment. Dynamically instantiate, subscribe events, invoke methods, and set properties.

![alt text](http://i.imgur.com/xbr2D0i.png "Main Window")

![alt text](http://i.imgur.com/QwiHfoK.png "GAC Dialog")

Features:
- Load 3rd party assemblies into the application’s domain.
- Load assemblies from the GAC into the application’s domain.
- Instantiate Types (even with constructors that have parameters).
- Set properties of the loaded instance.
- Invoke methods of the loaded instance (even those with parameters. Generics not supported).
- Modify the loaded object’s state with custom code. While the code-box has focus, press F5 to compile and run code.
- Subscribe to and log events of the loaded instance with a simple CheckedListBox.
- Search MSDN for more information about various things (press F1 to lookup the active element).
- Gets basic info about selected elements. For instance, when a property is selected, it is reflected upon so it can be described in the info window. The properties characteristics will be expressed as auto-implemented property code, but this is not necessarily how the property was defined.
- Easily collapse and expand views (press “Ctrl + M, L” to expand or collapse all quick-views in the left-most toolbar).
