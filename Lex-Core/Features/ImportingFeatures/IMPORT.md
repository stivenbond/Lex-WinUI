# File Importing Features
## Office Files
- The uses should have the ability to choose office files ( .docx, .xlsx, .pptx ) and import their content to the app's database.
- the data should be adjusted to the apps database schema
  - in the case of Word documents, the content would be imported as a lesson. the user should confirm the import before it is finalized and should have the ability to change how the document is imported to the apps database (for example, the user can shoose to import a single word document as multiple lessons and choose a custom way of how this document will be imported by the app and split it before the import transaction is complete). The word document can also hold diary information in the form of a table. these tables should be parsed and the data should be handled accordingly.
  - in the case of powerpoints the slides are imported as lesson content blocks and would follow the same logic as Word documents, where a word document could be imported and split into multiple lessons.
  - in the case of an excel file the user shouldchoose how the data that is being importing willbe mapped to the db schema, usually a JSON one.
- the user should be shown a preview of how a file would be imported and should be given the possibility of changing the data in the preview before confirming.
### Parsing logic
- the original documents are parsed into html via the mammoth library and then rganised in the Lex database schema with content blocks and their corresponding metadata.
## Attachments
- imported attachments should be marked by type based on the file extention and then stored as blobs in the database. if the attachment is more than 5MB in size, the path of the attachment will be stored as a URI in the database and the user should be warned that the attachment should not be moved, because the linking might break.
