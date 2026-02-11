## Field names for diary etries
Number (Nr)
Topic (Tema)
Homework (Detyra Shtepie)
DiaryPage (Fq Ditari)
LearningSituation (Situata e të nxënit)
MethodologyAndActivities (Metodologjia dhe veprimtaritë e nxënësve)
Assessment (Vlerësimi)
Resources (Burimet)
KeyCompetencyResults (Rezultatet e të nxënit sipas kompetencave kyç)
Keywords (Fjalët kyç)
InterdisciplinaryLinks (Lidhja me fusha të tjera ose me temat ndërkurrikulare)
LessonOrganization (Organizimi i orës së mësimit)
AcquiredCompetencies (Kompetencat që përfitojnë)
Week (Java)

## Json Schema
```json
{
  "$schema": "http://json-schema.org/draft-07/schema#",
  "title": "DiaryEntry",
  "type": "object",
  "properties": {
    "DiaryEntry": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "Albanian Field Name": { "type": "string" },
          "Content": {
            "type": "array",
            "items": { "type": "string" }
          }
        },
        "required": ["Albanian Field Name", "Content"]
      }
    }
  },
  "required": ["DiaryEntry"]
}
```

## Example Json Entry
```json
{
  "DiaryEntry": [
    {
      "Albanian Field Name": "Nr",
      "Content": ["1"]
    },
    {
      "Albanian Field Name": "Tema",
      "Content": ["Introduction to Database Normalization"]
    },
    {
      "Albanian Field Name": "Detyra Shtepie",
      "Content": ["Complete exercises 1 through 5 on page 42"]
    },
    {
      "Albanian Field Name": "Fq Ditari",
      "Content": ["12"]
    },
    {
      "Albanian Field Name": "Situata e të nxënit",
      "Content": ["Analyzing a messy spreadsheet to identify redundancies."]
    },
    {
      "Albanian Field Name": "Metodologjia dhe veprimtaritë e nxënësve",
      "Content": ["Brainstorming, Group Discussion, Practical Lab Work"]
    },
    {
      "Albanian Field Name": "Vlerësimi",
      "Content": ["Observation of group participation and accuracy of the logic model."]
    },
    {
      "Albanian Field Name": "Burimet",
      "Content": ["Textbook, SQL Server Management Studio, Projector"]
    },
    {
      "Albanian Field Name": "Rezultatet e të nxënit sipas kompetencave kyç",
      "Content": ["Student identifies data anomalies and applies 1NF, 2NF, and 3NF."]
    },
    {
      "Albanian Field Name": "Fjalët kyç",
      "Content": ["Primary Key, Foreign Key, Normalization, Dependency"]
    },
    {
      "Albanian Field Name": "Lidhja me fusha të tjera ose me temat ndërkurrikulare",
      "Content": ["Mathematics (Set Theory), English (Technical Terminology)"]
    },
    {
      "Albanian Field Name": "Organizimi i orës së mësimit",
      "Content": ["10 min Intro, 25 min Lab, 10 min Reflection"]
    },
    {
      "Albanian Field Name": "Kompetencat që përfitojnë",
      "Content": ["Problem solving, Logical thinking, Digital literacy"]
    },
    {
      "Albanian Field Name": "Java",
      "Content": ["3"]
    },
    {
      "Albanian Field Name": "Java",
      "Content": ["3"]
    }
  ]
}```