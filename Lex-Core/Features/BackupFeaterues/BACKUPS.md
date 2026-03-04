# Data Backup Features

## Versioning
    - The user has the ability to save a draft version ( auto-saved), a current working version, and a past version of the document for rollback

## Backups
    - The user has the ability to store a duplicate version of the SQLite Database File with naming of "LEX-<Date-of-export>.db"
    - The user has an ability to export the contents of the database as an archive whith the data organised in folders and the data stored as csv and JSON/md or the original file format for attachments. the contents in the resulting folder are zipped by the app and given to the user as a zip file.
    - The user has the ability to restore the state of the app by importing a database file or a .zip of an export made with the app. the state of the app qill be completely restored so the user should be warned before making this procedure final.
    - The app does periodic backups weekly and stores the last 2 backups in the AppData directory of the system to roll back to in case of database cosrruption of fatal error having to do with state.