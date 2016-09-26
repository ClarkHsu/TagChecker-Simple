# **Tag Checker**
-----------------------------------------
This application is used to check the tag closure of input HTML string. 
The main algorithm is putting every expected closing tag into a stack whenever there is a open tag being found.

# **How to use**
-----------------------------------------
Double click to open the Tag_Checker.exe, then input or paste html string into the upper textbox, paragraph separated by "CR". Click the button then get the tag checking result in textbox below.

# **Code explanation**
-----------------------------------------
At present, the application can only handle a simple situation of tag definition, i.e. "an  opening  tag  is  enclosed  by  angle  brackets,  and contains exactly one upper case letter, for example \<T>, \<X>, \<S>. The corresponding closing tag will be the same letter preceded by the symbol /; for the examples above these would be \</T>, \</X>, \</S>."
While it is designed to adapt requirement changing by little code change, which follows the OCP. Anyone could implement the ITagDefinition interface to tell about what a valid tag looks like,  then nothing else need to modify, the application can be OK to the new definition.


Technologies used: C#,.NET 3.5, Winform, XML, IoC/DI, SOLID.


