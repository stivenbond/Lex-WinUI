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
`json
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
          "Field Name": { "type": "string" },
          "Albanian Translation": { "type": "string" },
          "Content": {
            "type": "array",
            "items": { "type": "string" }
          }
        },
        "required": ["Field Name", "Albanian Translation", "Content"]
      }
    }
  },
  "required": ["DiaryEntry"]
}
`

## Example Json Entry
`json
{
  "DiaryEntry": [
    {
      "Field Name": "Number",
      "Albanian Translation": "Nr",
      "Content": ["1"]
    },
    {
      "Field Name": "Topic",
      "Albanian Translation": "Tema",
      "Content": ["Introduction to Database Normalization"]
    },
    {
      "Field Name": "Homework",
      "Albanian Translation": "Detyra Shtepie",
      "Content": ["Complete exercises 1 through 5 on page 42"]
    },
    {
      "Field Name": "DiaryPage",
      "Albanian Translation": "Fq Ditari",
      "Content": ["12"]
    },
    {
      "Field Name": "LearningSituation",
      "Albanian Translation": "Situata e të nxënit",
      "Content": ["Analyzing a messy spreadsheet to identify redundancies."]
    },
    {
      "Field Name": "MethodologyAndActivities",
      "Albanian Translation": "Metodologjia dhe veprimtaritë e nxënësve",
      "Content": ["Brainstorming, Group Discussion, Practical Lab Work"]
    },
    {
      "Field Name": "Assessment",
      "Albanian Translation": "Vlerësimi",
      "Content": ["Observation of group participation and accuracy of the logic model."]
    },
    {
      "Field Name": "Resources",
      "Albanian Translation": "Burimet",
      "Content": ["Textbook, SQL Server Management Studio, Projector"]
    },
    {
      "Field Name": "KeyCompetencyResults",
      "Albanian Translation": "Rezultatet e të nxënit sipas kompetencave kyç",
      "Content": ["Student identifies data anomalies and applies 1NF, 2NF, and 3NF."]
    },
    {
      "Field Name": "Keywords",
      "Albanian Translation": "Fjalët kyç",
      "Content": ["Primary Key, Foreign Key, Normalization, Dependency"]
    },
    {
      "Field Name": "InterdisciplinaryLinks",
      "Albanian Translation": "Lidhja me fusha të tjera ose me temat ndërkurrikulare",
      "Content": ["Mathematics (Set Theory), English (Technical Terminology)"]
    },
    {
      "Field Name": "LessonOrganization",
      "Albanian Translation": "Organizimi i orës së mësimit",
      "Content": ["10 min Intro, 25 min Lab, 10 min Reflection"]
    },
    {
      "Field Name": "AcquiredCompetencies",
      "Albanian Translation": "Kompetencat që përfitojnë",
      "Content": ["Problem solving, Logical thinking, Digital literacy"]
    },
    {
      "Field Name": "Week",
      "Albanian Translation": "Java",
      "Content": ["3"]
    }
  ]
}`