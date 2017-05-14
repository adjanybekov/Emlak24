using System.ComponentModel.DataAnnotations;
using Wohnungstausch24.Resources;

namespace Wohnungstausch24.Models.Enums
{
    public enum FloorType
    {
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Screed")]
        Screed = 1,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Plastic")]
        Plastic = 2,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Carpet")]
        Carpet = 3,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Linoleum")]
        Linoleum = 4,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_ReadilyParquet")]
        ReadilyParquet = 5,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_DoubleFloor")]
        DoubleFloor = 6,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Laminate")]
        Laminate = 7,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_FlagginBoards")]
        FlagginBoards = 8,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Parquet")]
        Parquet = 9,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Marble")]
        Marble = 10,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Stone")]
        Stone = 11,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Terracotta")]
        Terracotta = 12,
        [Display(ResourceType = typeof(Resource), Name = "Enum_FloorType_Granite")]
        Granite = 13
    }
}
