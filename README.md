# UnityLanguageEditor
I created a Scriptable Object class for each language to be translated, in each class there is just a new string array of length 100.
I used a single EditorWindow to edit these arrays.
The EditorWindow has multiple tabs, one for each language.
There is also a Scriptable Object class called KeyValues that has a new string array of length 100 and a int variable x that is set to 0.
These are values that are shared between all languages. The array is to hold the names of each key, which is the same acroos each language. 
The int is to determine how many keys there are. 
The arrays are set to 100 for each language but we do not want all of these to be displayed, since we might not need that many.
So in the EditorWindow it displays the values for each key in each language using x as a max index.
there is a field below the keys in each language that has a label that says "Add new key:". This field is the same regardless of which tab you select.
Typing a string into this and clicking the button below it, which says "Add new Key", will increase x by 1 and insert the string typed into the keyValues array at index x.
this will add a new key accross all languages.
There is another button that says "Delete most recent Key".
Pressing this will subtract 1 from x, removing the most recent key from the editor across all languages.
This will not change the keyValue string or the value of the removed key in each language.
