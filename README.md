# **Tag Checker**
-----------------------------------------
This application is used to check the tag closure of input HTML string. 
The main algorithm is putting every expected closing tag into a stack whenever there is a open tag being found.

# **How to use**
-----------------------------------------
Double click to open the Tag_Checker.exe, then input or paste html string into the upper textbox, paragraph separated by "CR". Click the button then get the tag checking result in textbox below.

# **Code explanation**
-----------------------------------------
At present, the application can only support a simple situation of tag definition, that is 

"an  opening  tag  is  enclosed  by  angle  brackets,  and contains exactly one upper case letter, for example \<T>, \<X>, \<S>. The corresponding closing tag will be the same letter preceded by the symbol /; for the examples above these would be \</T>, \</X>, \</S>."

While it is designed to adapt requirement changing flexible. Anyone could attach a specific class that implements the ITagDefinition interface to tell about what a valid tag looks like, and modify the config.xml to tell spring.net which class to be injected, then nothing else need to modify, the application can be OK to the new definition. Ideally you could implement a dictionary that covers all the tag you want to recognize, which is the next job I am working on--during my leisure time =-( 


Technologies used: C#,.NET 3.5, Winform, XML, Spring.NET.


