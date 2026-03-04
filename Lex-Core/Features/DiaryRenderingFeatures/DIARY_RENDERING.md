# Diary Rendering Features

- The user can choose to export a daily diary, a weekly diary, or any singular diary entry in the supported formats following the predefined structure.
- The user should be able to design a template for the diary and should be able to include any combination of tables and formatted text.
- The user should be able to rerender the diary any time. 

## Template Formats and Exporting logic
- the user should render the diary data in the template and be able to export the diary as a pdf. 
- the app will store the rpeferred HTML template, will populate and aply css simple styling, and render this into a pdf using QuestPDF.
- the app will ask the user where to store the file and if it should remember this as a prefered folder for future exports. the user should be able to override this later on. 
- the app template should be stored by the app as text inside the database and the user should be able to store multiple templates if they want.
- the user will be able to store this file also as an office document, not by brute-forcing opening the html in word but by storing a docx template equivalent to the html and adding the entry content to this office file template, and letting the user export this office-format resulting file.
- upon html template update the equivalent office template should also be recompiled.