﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using MPF.Data;
#if NET_FRAMEWORK
using IMAPI2;
#endif
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedumpLib.Data;

namespace MPF.Converters
{
    public static class EnumConverter
    {
        #region Cross-enumeration conversions

        /// <summary>
        /// Convert drive type to internal version, if possible
        /// </summary>
        /// <param name="driveType">DriveType value to check</param>
        /// <returns>InternalDriveType, if possible, null on error</returns>
        public static InternalDriveType? ToInternalDriveType(this DriveType driveType)
        {
            switch (driveType)
            {
                case DriveType.CDRom:
                    return InternalDriveType.Optical;
                case DriveType.Fixed:
                    return InternalDriveType.HardDisk;
                case DriveType.Removable:
                    return InternalDriveType.Removable;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert currently known Redump systems to the master list of systems
        /// </summary>
        /// <param name="system">Redump system value to check</param>
        /// <returns>KnownSystem if possible, null on error</returns>
        public static KnownSystem? ToKnownSystem(this RedumpSystem? system)
        {
            switch (system)
            {
                // Special BIOS sets
                case RedumpSystem.MicrosoftXboxBIOS:
                    return KnownSystem.MicrosoftXBOX;
                case RedumpSystem.NintendoGameCubeBIOS:
                    return KnownSystem.NintendoGameCube;
                case RedumpSystem.SonyPlayStationBIOS:
                    return KnownSystem.SonyPlayStation;
                case RedumpSystem.SonyPlayStation2BIOS:
                    return KnownSystem.SonyPlayStation2;

                // Regular systems
                case RedumpSystem.AcornArchimedes:
                    return KnownSystem.AcornArchimedes;
                case RedumpSystem.AppleMacintosh:
                    return KnownSystem.AppleMacintosh;
                case RedumpSystem.AudioCD:
                    return KnownSystem.AudioCD;
                case RedumpSystem.BandaiPippin:
                    return KnownSystem.BandaiApplePippin;
                case RedumpSystem.BandaiPlaydiaQuickInteractiveSystem:
                    return KnownSystem.BandaiPlaydiaQuickInteractiveSystem;
                case RedumpSystem.BDVideo:
                    return KnownSystem.BDVideo;
                case RedumpSystem.CommodoreAmigaCD:
                    return KnownSystem.CommodoreAmiga;
                case RedumpSystem.CommodoreAmigaCD32:
                    return KnownSystem.CommodoreAmigaCD32;
                case RedumpSystem.CommodoreAmigaCDTV:
                    return KnownSystem.CommodoreAmigaCDTV;
                case RedumpSystem.DVDVideo:
                    return KnownSystem.DVDVideo;
                case RedumpSystem.EnhancedCD:
                    return KnownSystem.EnhancedCD;
                case RedumpSystem.FujitsuFMTownsseries:
                    return KnownSystem.FujitsuFMTowns;
                case RedumpSystem.funworldPhotoPlay:
                    return KnownSystem.funworldPhotoPlay;
                case RedumpSystem.HasbroVideoNow:
                    return KnownSystem.HasbroVideoNow;
                case RedumpSystem.HasbroVideoNowColor:
                    return KnownSystem.HasbroVideoNowColor;
                case RedumpSystem.HasbroVideoNowJr:
                    return KnownSystem.HasbroVideoNowJr;
                case RedumpSystem.HasbroVideoNowXP:
                    return KnownSystem.HasbroVideoNowXP;
                case RedumpSystem.HDDVDVideo:
                    return KnownSystem.HDDVDVideo;
                case RedumpSystem.IBMPCcompatible:
                    return KnownSystem.IBMPCCompatible;
                case RedumpSystem.IncredibleTechnologiesEagle:
                    return KnownSystem.IncredibleTechnologiesEagle;
                case RedumpSystem.KonamieAmusement:
                    return KnownSystem.KonamieAmusement;
                case RedumpSystem.KonamiFireBeat:
                    return KnownSystem.KonamiFirebeat;
                case RedumpSystem.KonamiM2:
                    return KnownSystem.KonamiM2;
                case RedumpSystem.KonamiSystem573:
                    return KnownSystem.KonamiSystem573;
                case RedumpSystem.KonamiSystemGV:
                    return KnownSystem.KonamiGVSystem;
                case RedumpSystem.KonamiTwinkle:
                    return KnownSystem.KonamiTwinkle;
                case RedumpSystem.MattelFisherPriceiXL:
                    return KnownSystem.MattelFisherPriceiXL;
                case RedumpSystem.MattelHyperScan:
                    return KnownSystem.MattelHyperscan;
                case RedumpSystem.MemorexVisualInformationSystem:
                    return KnownSystem.TandyMemorexVisualInformationSystem;
                case RedumpSystem.MicrosoftXbox:
                    return KnownSystem.MicrosoftXBOX;
                case RedumpSystem.MicrosoftXbox360:
                    return KnownSystem.MicrosoftXBOX360;
                case RedumpSystem.MicrosoftXboxOne:
                    return KnownSystem.MicrosoftXBOXOne;
                case RedumpSystem.NECPC88series:
                    return KnownSystem.NECPC88;
                case RedumpSystem.NECPC98series:
                    return KnownSystem.NECPC98;
                case RedumpSystem.NECPCEngineCDTurboGrafxCD:
                    return KnownSystem.NECPCEngineTurboGrafxCD;
                case RedumpSystem.NECPCFXPCFXGA:
                    return KnownSystem.NECPCFX;
                case RedumpSystem.NamcoSegaNintendoTriforce:
                    return KnownSystem.NamcoSegaNintendoTriforce;
                case RedumpSystem.NamcoSystem12:
                    return KnownSystem.NamcoSystem12;
                case RedumpSystem.NamcoSystem246:
                    return KnownSystem.NamcoCapcomTaitoSystem246;
                case RedumpSystem.NavisoftNaviken21:
                    return KnownSystem.NavisoftNaviken21;
                case RedumpSystem.NintendoGameCube:
                    return KnownSystem.NintendoGameCube;
                case RedumpSystem.NintendoWii:
                    return KnownSystem.NintendoWii;
                case RedumpSystem.NintendoWiiU:
                    return KnownSystem.NintendoWiiU;
                case RedumpSystem.PalmOS:
                    return KnownSystem.PalmOS;
                case RedumpSystem.Panasonic3DOInteractiveMultiplayer:
                    return KnownSystem.Panasonic3DOInteractiveMultiplayer;
                case RedumpSystem.PanasonicM2:
                    return KnownSystem.PanasonicM2;
                case RedumpSystem.PhilipsCDi:
                    return KnownSystem.PhilipsCDi;
                case RedumpSystem.PhotoCD:
                    return KnownSystem.PhotoCD;
                case RedumpSystem.PlayStationGameSharkUpdates:
                    return KnownSystem.PlayStationGameSharkUpdates;
                case RedumpSystem.PocketPC:
                    return KnownSystem.PocketPC;
                case RedumpSystem.SegaChihiro:
                    return KnownSystem.SegaChihiro;
                case RedumpSystem.SegaDreamcast:
                    return KnownSystem.SegaDreamcast;
                case RedumpSystem.SegaLindbergh:
                    return KnownSystem.SegaLindbergh;
                case RedumpSystem.SegaMegaCDSegaCD:
                    return KnownSystem.SegaCDMegaCD;
                case RedumpSystem.SegaNaomi:
                    return KnownSystem.SegaNaomi;
                case RedumpSystem.SegaNaomi2:
                    return KnownSystem.SegaNaomi2;
                case RedumpSystem.SegaPrologue21MultimediaKaraokeSystem:
                    return KnownSystem.SegaPrologue21;
                case RedumpSystem.SegaRingEdge:
                    return KnownSystem.SegaRingEdge;
                case RedumpSystem.SegaRingEdge2:
                    return KnownSystem.SegaRingEdge2;
                case RedumpSystem.SegaSaturn:
                    return KnownSystem.SegaSaturn;
                case RedumpSystem.SegaTitanVideo:
                    return KnownSystem.SegaTitanVideo;
                case RedumpSystem.SharpX68000:
                    return KnownSystem.SharpX68000;
                case RedumpSystem.SNKNeoGeoCD:
                    return KnownSystem.SNKNeoGeoCD;
                case RedumpSystem.SonyPlayStation:
                    return KnownSystem.SonyPlayStation;
                case RedumpSystem.SonyPlayStation2:
                    return KnownSystem.SonyPlayStation2;
                case RedumpSystem.SonyPlayStation3:
                    return KnownSystem.SonyPlayStation3;
                case RedumpSystem.SonyPlayStation4:
                    return KnownSystem.SonyPlayStation4;
                case RedumpSystem.SonyPlayStationPortable:
                    return KnownSystem.SonyPlayStationPortable;
                case RedumpSystem.TABAustriaQuizard:
                    return KnownSystem.TABAustriaQuizard;
                case RedumpSystem.TaoiKTV:
                    return KnownSystem.TaoiKTV;
                case RedumpSystem.TomyKissSite:
                    return KnownSystem.TomyKissSite;
                case RedumpSystem.VideoCD:
                    return KnownSystem.VideoCD;
                case RedumpSystem.VMLabsNUON:
                    return KnownSystem.VMLabsNuon;
                case RedumpSystem.VTechVFlashVSmilePro:
                    return KnownSystem.VTechVFlashVSmilePro;
                case RedumpSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem:
                    return KnownSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem;
                default:
                    return null;
            }
        }

#if NET_FRAMEWORK
        /// <summary>
        /// Convert IMAPI physical media type to a MediaType
        /// </summary>
        /// <param name="type">IMAPI_MEDIA_PHYSICAL_TYPE value to check</param>
        /// <returns>MediaType if possible, null on error</returns>
        public static MediaType? IMAPIToMediaType(this IMAPI_MEDIA_PHYSICAL_TYPE type)
        {
            switch (type)
            {
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN:
                    return MediaType.NONE;
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDROM:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDR:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDRW:
                    return MediaType.CDROM;
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDROM:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDRAM:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHRW:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER:
                    return MediaType.DVD;
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDROM:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDR:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDRAM:
                    return MediaType.HDDVD;
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDROM:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDR:
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDRE:
                    return MediaType.BluRay;
                default:
                    return null;
            }
        }
#endif

        /// <summary>
        /// Convert physical media type to a MediaType
        /// </summary>
        /// <param name="type">PhsyicalMediaType value to check</param>
        /// <returns>MediaType if possible, null on error</returns>
        public static MediaType? ToMediaType(this PhysicalMediaType type)
        {
            switch (type)
            {
                case PhysicalMediaType.Unknown:
                    return MediaType.NONE;

                // CD-based media
                case PhysicalMediaType.CDROM:
                case PhysicalMediaType.CDROMXA:
                case PhysicalMediaType.CDI:
                case PhysicalMediaType.CDRecordable:
                case PhysicalMediaType.CDRW:
                case PhysicalMediaType.CDDA:
                case PhysicalMediaType.CDPlus:
                    return MediaType.CDROM;

                // DVD-based media
                case PhysicalMediaType.DVD:
                case PhysicalMediaType.DVDPlusRW:
                case PhysicalMediaType.DVDRAM:
                case PhysicalMediaType.DVDROM:
                case PhysicalMediaType.DVDVideo:
                case PhysicalMediaType.DVDRecordable:
                case PhysicalMediaType.DVDMinusRW:
                case PhysicalMediaType.DVDAudio:
                case PhysicalMediaType.DVD5:
                case PhysicalMediaType.DVD9:
                case PhysicalMediaType.DVD10:
                case PhysicalMediaType.DVD18:
                    return MediaType.DVD;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert master list of all systems to currently known Redump systems
        /// </summary>
        /// <param name="system">KnownSystem value to check</param>
        /// <returns>RedumpSystem if possible, null on error</returns>
        public static RedumpSystem? ToRedumpSystem(this KnownSystem? system)
        {
            switch (system)
            {
                case KnownSystem.AcornArchimedes:
                    return RedumpSystem.AcornArchimedes;
                case KnownSystem.AppleMacintosh:
                    return RedumpSystem.AppleMacintosh;
                case KnownSystem.AudioCD:
                    return RedumpSystem.AudioCD;
                case KnownSystem.BandaiApplePippin:
                    return RedumpSystem.BandaiPippin;
                case KnownSystem.BandaiPlaydiaQuickInteractiveSystem:
                    return RedumpSystem.BandaiPlaydiaQuickInteractiveSystem;
                case KnownSystem.BDVideo:
                    return RedumpSystem.BDVideo;
                case KnownSystem.CommodoreAmiga:
                    return RedumpSystem.CommodoreAmigaCD;
                case KnownSystem.CommodoreAmigaCD32:
                    return RedumpSystem.CommodoreAmigaCD32;
                case KnownSystem.CommodoreAmigaCDTV:
                    return RedumpSystem.CommodoreAmigaCDTV;
                case KnownSystem.DVDVideo:
                    return RedumpSystem.DVDVideo;
                case KnownSystem.EnhancedCD:
                    return RedumpSystem.EnhancedCD;
                case KnownSystem.FujitsuFMTowns:
                    return RedumpSystem.FujitsuFMTownsseries;
                case KnownSystem.funworldPhotoPlay:
                    return RedumpSystem.funworldPhotoPlay;
                case KnownSystem.HasbroVideoNow:
                    return RedumpSystem.HasbroVideoNow;
                case KnownSystem.HasbroVideoNowColor:
                    return RedumpSystem.HasbroVideoNowColor;
                case KnownSystem.HasbroVideoNowJr:
                    return RedumpSystem.HasbroVideoNowJr;
                case KnownSystem.HasbroVideoNowXP:
                    return RedumpSystem.HasbroVideoNowXP;
                case KnownSystem.HDDVDVideo:
                    return RedumpSystem.HDDVDVideo;
                case KnownSystem.IBMPCCompatible:
                    return RedumpSystem.IBMPCcompatible;
                case KnownSystem.IncredibleTechnologiesEagle:
                    return RedumpSystem.IncredibleTechnologiesEagle;
                case KnownSystem.KonamieAmusement:
                    return RedumpSystem.KonamieAmusement;
                case KnownSystem.KonamiFirebeat:
                    return RedumpSystem.KonamiFireBeat;
                case KnownSystem.KonamiM2:
                    return RedumpSystem.KonamiM2;
                case KnownSystem.KonamiSystem573:
                    return RedumpSystem.KonamiSystem573;
                case KnownSystem.KonamiGVSystem:
                    return RedumpSystem.KonamiSystemGV;
                case KnownSystem.KonamiTwinkle:
                    return RedumpSystem.KonamiTwinkle;
                case KnownSystem.MattelFisherPriceiXL:
                    return RedumpSystem.MattelFisherPriceiXL;
                case KnownSystem.MattelHyperscan:
                    return RedumpSystem.MattelHyperScan;
                case KnownSystem.TandyMemorexVisualInformationSystem:
                    return RedumpSystem.MemorexVisualInformationSystem;
                case KnownSystem.MicrosoftXBOX:
                    return RedumpSystem.MicrosoftXbox; // RedumpSystem.MicrosoftXboxBIOS
                case KnownSystem.MicrosoftXBOX360:
                    return RedumpSystem.MicrosoftXbox360;
                case KnownSystem.MicrosoftXBOXOne:
                    return RedumpSystem.MicrosoftXboxOne;
                case KnownSystem.NamcoSegaNintendoTriforce:
                    return RedumpSystem.NamcoSegaNintendoTriforce;
                case KnownSystem.NamcoSystem12:
                    return RedumpSystem.NamcoSystem12;
                case KnownSystem.NamcoCapcomTaitoSystem246:
                    return RedumpSystem.NamcoSystem246;
                case KnownSystem.NavisoftNaviken21:
                    return RedumpSystem.NavisoftNaviken21;
                case KnownSystem.NECPCEngineTurboGrafxCD:
                    return RedumpSystem.NECPCEngineCDTurboGrafxCD;
                case KnownSystem.NECPC88:
                    return RedumpSystem.NECPC88series;
                case KnownSystem.NECPC98:
                    return RedumpSystem.NECPC98series;
                case KnownSystem.NECPCFX:
                    return RedumpSystem.NECPCFXPCFXGA;
                case KnownSystem.NintendoGameCube:
                    return RedumpSystem.NintendoGameCube; // RedumpSystem.NintendoGameCubeBIOS;
                case KnownSystem.NintendoWii:
                    return RedumpSystem.NintendoWii;
                case KnownSystem.NintendoWiiU:
                    return RedumpSystem.NintendoWiiU;
                case KnownSystem.PalmOS:
                    return RedumpSystem.PalmOS;
                case KnownSystem.Panasonic3DOInteractiveMultiplayer:
                    return RedumpSystem.Panasonic3DOInteractiveMultiplayer;
                case KnownSystem.PanasonicM2:
                    return RedumpSystem.PanasonicM2;
                case KnownSystem.PhilipsCDi:
                    return RedumpSystem.PhilipsCDi;
                case KnownSystem.PhotoCD:
                    return RedumpSystem.PhotoCD;
                case KnownSystem.PlayStationGameSharkUpdates:
                    return RedumpSystem.PlayStationGameSharkUpdates;
                case KnownSystem.PocketPC:
                    return RedumpSystem.PocketPC;
                case KnownSystem.SegaChihiro:
                    return RedumpSystem.SegaChihiro;
                case KnownSystem.SegaDreamcast:
                    return RedumpSystem.SegaDreamcast;
                case KnownSystem.SegaLindbergh:
                    return RedumpSystem.SegaLindbergh;
                case KnownSystem.SegaCDMegaCD:
                    return RedumpSystem.SegaMegaCDSegaCD;
                case KnownSystem.SegaNaomi:
                    return RedumpSystem.SegaNaomi;
                case KnownSystem.SegaNaomi2:
                    return RedumpSystem.SegaNaomi2;
                case KnownSystem.SegaPrologue21:
                    return RedumpSystem.SegaPrologue21MultimediaKaraokeSystem;
                case KnownSystem.SegaRingEdge:
                    return RedumpSystem.SegaRingEdge;
                case KnownSystem.SegaRingEdge2:
                    return RedumpSystem.SegaRingEdge2;
                case KnownSystem.SegaSaturn:
                    return RedumpSystem.SegaSaturn;
                case KnownSystem.SegaTitanVideo:
                    return RedumpSystem.SegaTitanVideo;
                case KnownSystem.SharpX68000:
                    return RedumpSystem.SharpX68000;
                case KnownSystem.SNKNeoGeoCD:
                    return RedumpSystem.SNKNeoGeoCD;
                case KnownSystem.SonyPlayStation:
                    return RedumpSystem.SonyPlayStation; // RedumpSystem.SonyPlayStationBIOS;
                case KnownSystem.SonyPlayStation2:
                    return RedumpSystem.SonyPlayStation2; // RedumpSystem.SonyPlayStation2BIOS;
                case KnownSystem.SonyPlayStation3:
                    return RedumpSystem.SonyPlayStation3;
                case KnownSystem.SonyPlayStation4:
                    return RedumpSystem.SonyPlayStation4;
                case KnownSystem.SonyPlayStationPortable:
                    return RedumpSystem.SonyPlayStationPortable;
                case KnownSystem.TABAustriaQuizard:
                    return RedumpSystem.TABAustriaQuizard;
                case KnownSystem.TaoiKTV:
                    return RedumpSystem.TaoiKTV;
                case KnownSystem.TomyKissSite:
                    return RedumpSystem.TomyKissSite;
                case KnownSystem.VideoCD:
                    return RedumpSystem.VideoCD;
                case KnownSystem.VMLabsNuon:
                    return RedumpSystem.VMLabsNUON;
                case KnownSystem.VTechVFlashVSmilePro:
                    return RedumpSystem.VTechVFlashVSmilePro;
                case KnownSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem:
                    return RedumpSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem;
                default:
                    return null;
            }
        }

        #endregion

        #region Convert to Long Name

        /// <summary>
        /// Long name method cache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, MethodInfo> LongNameMethods = new ConcurrentDictionary<Type, MethodInfo>();

        /// <summary>
        /// Get the string representation of a generic enumerable value
        /// </summary>
        /// <param name="value">Enum value to convert</param>
        /// <returns>String representation of that value if possible, empty string on error</returns>
        public static string GetLongName(Enum value)
        {
            try
            {
                var sourceType = value.GetType();
                sourceType = Nullable.GetUnderlyingType(sourceType) ?? sourceType;

                if (!LongNameMethods.TryGetValue(sourceType, out MethodInfo method))
                {
                    method = typeof(EnumConverter).GetMethod("LongName", new[] { typeof(Nullable<>).MakeGenericType(sourceType) });
                    LongNameMethods.TryAdd(sourceType, method);
                }

                if (method != null)
                    return method.Invoke(null, new[] { value }) as string;
                else
                    return string.Empty;
            }
            catch
            {
                // Converter is not implemented for the given type
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the string representation of the InternalProgram enum values
        /// </summary>
        /// <param name="prog">InternalProgram value to convert</param>
        /// <returns>String representing the value, if possible</returns>
        public static string LongName(this InternalProgram? prog)
        {
            switch (prog)
            {
                #region Dumping support

                case InternalProgram.Aaru:
                    return "Aaru";
                case InternalProgram.DD:
                    return "dd";
                case InternalProgram.DiscImageCreator:
                    return "DiscImageCreator";

                #endregion

                #region Verification support only

                case InternalProgram.CleanRip:
                    return "CleanRip";

                case InternalProgram.DCDumper:
                    return "DCDumper";

                case InternalProgram.UmdImageCreator:
                    return "UmdImageCreator";

                #endregion

                case InternalProgram.NONE:
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Get the string representation of the KnownSystem enum values
        /// </summary>
        /// <param name="sys">KnownSystem value to convert</param>
        /// <returns>String representing the value, if possible</returns>
        public static string LongName(this KnownSystem? sys)
        {
            switch (sys)
            {
                #region Consoles

                case KnownSystem.AtariJaguarCD:
                    return "Atari Jaguar CD";
                case KnownSystem.BandaiPlaydiaQuickInteractiveSystem:
                    return "Bandai Playdia Quick Interactive System";
                case KnownSystem.BandaiApplePippin:
                    return "Bandai / Apple Pippin";
                case KnownSystem.CommodoreAmigaCD32:
                    return "Commodore Amiga CD32";
                case KnownSystem.CommodoreAmigaCDTV:
                    return "Commodore Amiga CDTV";
                case KnownSystem.EnvizionsEVOSmartConsole:
                    return "Envizions EVO Smart Console";
                case KnownSystem.FujitsuFMTownsMarty:
                    return "Fujitsu FM Towns Marty";
                case KnownSystem.HasbroVideoNow:
                    return "Hasbro VideoNow";
                case KnownSystem.HasbroVideoNowColor:
                    return "Hasbro VideoNow Color";
                case KnownSystem.HasbroVideoNowJr:
                    return "Hasbro VideoNow Jr.";
                case KnownSystem.HasbroVideoNowXP:
                    return "Hasbro VideoNow XP";
                case KnownSystem.MattelFisherPriceiXL:
                    return "Mattel Fisher-Price iXL";
                case KnownSystem.MattelHyperscan:
                    return "Mattel HyperScan";
                case KnownSystem.MicrosoftXBOX:
                    return "Microsoft XBOX";
                case KnownSystem.MicrosoftXBOX360:
                    return "Microsoft XBOX 360";
                case KnownSystem.MicrosoftXBOXOne:
                    return "Microsoft XBOX One";
                case KnownSystem.MicrosoftXboxSeriesXS:
                    return "Microsoft XBOX Series X and S";
                case KnownSystem.NECPCEngineTurboGrafxCD:
                    return "NEC PC-Engine / TurboGrafx CD";
                case KnownSystem.NECPCFX:
                    return "NEC PC-FX / PC-FXGA";
                case KnownSystem.NintendoGameCube:
                    return "Nintendo GameCube";
                case KnownSystem.NintendoSonySuperNESCDROMSystem:
                    return "Nintendo-Sony Super NES CD-ROM System";
                case KnownSystem.NintendoWii:
                    return "Nintendo Wii";
                case KnownSystem.NintendoWiiU:
                    return "Nintendo Wii U";
                case KnownSystem.Panasonic3DOInteractiveMultiplayer:
                    return "Panasonic 3DO Interactive Multiplayer";
                case KnownSystem.PhilipsCDi:
                    return "Philips CD-i";
                case KnownSystem.PioneerLaserActive:
                    return "Pioneer LaserActive";
                case KnownSystem.SegaCDMegaCD:
                    return "Sega CD / Mega CD";
                case KnownSystem.SegaDreamcast:
                    return "Sega Dreamcast";
                case KnownSystem.SegaSaturn:
                    return "Sega Saturn";
                case KnownSystem.SNKNeoGeoCD:
                    return "SNK Neo Geo CD";
                case KnownSystem.SonyPlayStation:
                    return "Sony PlayStation";
                case KnownSystem.SonyPlayStation2:
                    return "Sony PlayStation 2";
                case KnownSystem.SonyPlayStation3:
                    return "Sony PlayStation 3";
                case KnownSystem.SonyPlayStation4:
                    return "Sony PlayStation 4";
                case KnownSystem.SonyPlayStation5:
                    return "Sony PlayStation 5";
                case KnownSystem.SonyPlayStationPortable:
                    return "Sony PlayStation Portable";
                case KnownSystem.TandyMemorexVisualInformationSystem:
                    return "Tandy / Memorex Visual Information System";
                case KnownSystem.VMLabsNuon:
                    return "VM Labs NUON";
                case KnownSystem.VTechVFlashVSmilePro:
                    return "VTech V.Flash - V.Smile Pro";
                case KnownSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem:
                    return "ZAPiT Games Game Wave Family Entertainment System";

                #endregion

                #region Computers

                case KnownSystem.AcornArchimedes:
                    return "Acorn Archimedes";
                case KnownSystem.AppleMacintosh:
                    return "Apple Macintosh";
                case KnownSystem.CommodoreAmiga:
                    return "Commodore Amiga";
                case KnownSystem.FujitsuFMTowns:
                    return "Fujitsu FM Towns series";
                case KnownSystem.IBMPCCompatible:
                    return "IBM PC Compatible";
                case KnownSystem.NECPC88:
                    return "NEC PC-88";
                case KnownSystem.NECPC98:
                    return "NEC PC-98";
                case KnownSystem.SharpX68000:
                    return "Sharp X68000";

                #endregion

                #region Arcade

                case KnownSystem.AmigaCUBOCD32:
                    return "Amiga CUBO CD32";
                case KnownSystem.AmericanLaserGames3DO:
                    return "American Laser Games 3DO";
                case KnownSystem.Atari3DO:
                    return "Atari 3DO";
                case KnownSystem.Atronic:
                    return "Atronic";
                case KnownSystem.AUSCOMSystem1:
                    return "AUSCOM System 1";
                case KnownSystem.BallyGameMagic:
                    return "Bally Game Magic";
                case KnownSystem.CapcomCPSystemIII:
                    return "Capcom CP System III";
                case KnownSystem.funworldPhotoPlay:
                    return "funworld Photo Play";
                case KnownSystem.GlobalVRVarious:
                    return "Global VR PC-based Systems";
                case KnownSystem.GlobalVRVortek:
                    return "Global VR Vortek";
                case KnownSystem.GlobalVRVortekV3:
                    return "Global VR Vortek V3";
                case KnownSystem.ICEPCHardware:
                    return "ICE PC-based Hardware";
                case KnownSystem.IncredibleTechnologiesEagle:
                    return "Incredible Technologies Eagle";
                case KnownSystem.IncredibleTechnologiesVarious:
                    return "Incredible Technologies PC-based Systems";
                case KnownSystem.KonamieAmusement:
                    return "Konami e-Amusement";
                case KnownSystem.KonamiFirebeat:
                    return "Konami Firebeat";
                case KnownSystem.KonamiGVSystem:
                    return "Konami GV System";
                case KnownSystem.KonamiM2:
                    return "Konami M2";
                case KnownSystem.KonamiPython:
                    return "Konami Python";
                case KnownSystem.KonamiPython2:
                    return "Konami Python 2";
                case KnownSystem.KonamiSystem573:
                    return "Konami System 573";
                case KnownSystem.KonamiTwinkle:
                    return "Konami Twinkle";
                case KnownSystem.KonamiVarious:
                    return "Konami PC-based Systems";
                case KnownSystem.MeritIndustriesBoardwalk:
                    return "Merit Industries Boardwalk";
                case KnownSystem.MeritIndustriesMegaTouchForce:
                    return "Merit Industries MegaTouch Force";
                case KnownSystem.MeritIndustriesMegaTouchION:
                    return "Merit Industries MegaTouch ION";
                case KnownSystem.MeritIndustriesMegaTouchMaxx:
                    return "Merit Industries MegaTouch Maxx";
                case KnownSystem.MeritIndustriesMegaTouchXL:
                    return "Merit Industries MegaTouch XL";
                case KnownSystem.NamcoCapcomSystem256:
                    return "Namco / Capcom System 256/Super System 256";
                case KnownSystem.NamcoCapcomTaitoSystem246:
                    return "Namco / Capcom / Taito System 246";
                case KnownSystem.NamcoSegaNintendoTriforce:
                    return "Namco / Sega / Nintendo Triforce";
                case KnownSystem.NamcoSystem12:
                    return "Namco System 12";
                case KnownSystem.NamcoSystem357:
                    return "Namco System 357";
                case KnownSystem.NewJatreCDi:
                    return "New Jatre CD-i";
                case KnownSystem.NichibutsuHighRateSystem:
                    return "Nichibutsu High Rate System";
                case KnownSystem.NichibutsuSuperCD:
                    return "Nichibutsu Super CD";
                case KnownSystem.NichibutsuXRateSystem:
                    return "Nichibutsu X-Rate System";
                case KnownSystem.PanasonicM2:
                    return "Panasonic M2";
                case KnownSystem.PhotoPlayVarious:
                    return "PhotoPlay PC-based Systems";
                case KnownSystem.RawThrillsVarious:
                    return "Raw Thrills PC-based Systems";
                case KnownSystem.SegaChihiro:
                    return "Sega Chihiro";
                case KnownSystem.SegaEuropaR:
                    return "Sega Europa-R";
                case KnownSystem.SegaLindbergh:
                    return "Sega Lindbergh";
                case KnownSystem.SegaNaomi:
                    return "Sega Naomi";
                case KnownSystem.SegaNaomi2:
                    return "Sega Naomi 2";
                case KnownSystem.SegaNu:
                    return "Sega Nu";
                case KnownSystem.SegaRingEdge:
                    return "Sega RingEdge";
                case KnownSystem.SegaRingEdge2:
                    return "Sega RingEdge 2";
                case KnownSystem.SegaRingWide:
                    return "Sega RingWide";
                case KnownSystem.SegaTitanVideo:
                    return "Sega Titan Video";
                case KnownSystem.SegaSystem32:
                    return "Sega System 32";
                case KnownSystem.SeibuCATSSystem:
                    return "Seibu CATS System";
                case KnownSystem.TABAustriaQuizard:
                    return "TAB-Austria Quizard";
                case KnownSystem.TsunamiTsuMoMultiGameMotionSystem:
                    return "Tsunami TsuMo Multi-Game Motion System";

                #endregion

                #region Others

                case KnownSystem.AudioCD:
                    return "Audio CD";
                case KnownSystem.BDVideo:
                    return "BD-Video";
                case KnownSystem.DVDAudio:
                    return "DVD-Audio";
                case KnownSystem.DVDVideo:
                    return "DVD-Video";
                case KnownSystem.EnhancedCD:
                    return "Enhanced CD";
                case KnownSystem.HDDVDVideo:
                    return "HD-DVD-Video";
                case KnownSystem.NavisoftNaviken21:
                    return "Navisoft Naviken 2.1";
                case KnownSystem.PalmOS:
                    return "PalmOS";
                case KnownSystem.PhotoCD:
                    return "Photo CD";
                case KnownSystem.PlayStationGameSharkUpdates:
                    return "PlayStation GameShark Updates";
                case KnownSystem.PocketPC:
                    return "Pocket PC";
                case KnownSystem.RainbowDisc:
                    return "Rainbow Disc";
                case KnownSystem.SegaPrologue21:
                    return "Sega Prologue 21";
                case KnownSystem.SuperAudioCD:
                    return "Super Audio CD";
                case KnownSystem.TaoiKTV:
                    return "Tao iKTV";
                case KnownSystem.TomyKissSite:
                    return "Tomy Kiss-Site";
                case KnownSystem.VideoCD:
                    return "Video CD";

                #endregion

                case KnownSystem.NONE:
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Get the string representation of the KnownSystemCategory enum values
        /// </summary>
        /// <param name="category">KnownSystemCategory value to convert</param>
        /// <returns>String representing the value, if possible</returns>
        public static string LongName(this KnownSystemCategory? category)
        {
            switch (category)
            {
                case KnownSystemCategory.Arcade:
                    return "Arcade";
                case KnownSystemCategory.Computer:
                    return "Computers";
                case KnownSystemCategory.DiscBasedConsole:
                    return "Disc-Based Consoles";
                case KnownSystemCategory.OtherConsole:
                    return "Other Consoles";
                case KnownSystemCategory.Other:
                    return "Other";
                case KnownSystemCategory.Custom:
                    return "Custom";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Get the string representation of the MediaType enum values
        /// </summary>
        /// <param name="type">MediaType value to convert</param>
        /// <returns>String representing the value, if possible</returns>
        public static string LongName(this MediaType? type)
        {
            switch (type)
            {
                #region Punched Media

                case MediaType.ApertureCard:
                    return "Aperture card";
                case MediaType.JacquardLoomCard:
                    return "Jacquard Loom card";
                case MediaType.MagneticStripeCard:
                    return "Magnetic stripe card";
                case MediaType.OpticalPhonecard:
                    return "Optical phonecard";
                case MediaType.PunchedCard:
                    return "Punched card";
                case MediaType.PunchedTape:
                    return "Punched tape";

                #endregion

                #region Tape

                case MediaType.OpenReel:
                    return "Open Reel Tape";
                case MediaType.DataCartridge:
                    return "Data Tape Cartridge";
                case MediaType.Cassette:
                    return "Cassette Tape";

                #endregion

                #region Disc / Disc

                case MediaType.BluRay:
                    return "BD-ROM";
                case MediaType.CDROM:
                    return "CD-ROM";
                case MediaType.DVD:
                    return "DVD-ROM";
                case MediaType.FloppyDisk:
                    return "Floppy Disk";
                case MediaType.Floptical:
                    return "Floptical";
                case MediaType.GDROM:
                    return "GD-ROM";
                case MediaType.HDDVD:
                    return "HD-DVD-ROM";
                case MediaType.HardDisk:
                    return "Hard Disk";
                case MediaType.IomegaBernoulliDisk:
                    return "Iomega Bernoulli Disk";
                case MediaType.IomegaJaz:
                    return "Iomega Jaz";
                case MediaType.IomegaZip:
                    return "Iomega Zip";
                case MediaType.LaserDisc:
                    return "LD-ROM / LV-ROM";
                case MediaType.Nintendo64DD:
                    return "64DD Disk";
                case MediaType.NintendoFamicomDiskSystem:
                    return "Famicom Disk System Disk";
                case MediaType.NintendoGameCubeGameDisc:
                    return "GameCube Game Disc";
                case MediaType.NintendoWiiOpticalDisc:
                    return "Wii Optical Disc";
                case MediaType.NintendoWiiUOpticalDisc:
                    return "Wii U Optical Disc";
                case MediaType.UMD:
                    return "UMD";

                #endregion

                // Unsorted Formats
                case MediaType.Cartridge:
                    return "Cartridge";
                case MediaType.CED:
                    return "CED";

                case MediaType.NONE:
                default:
                    return "Unknown";
            }
        }

        /// <summary>
        /// Get the string representation of the YesNo enum values
        /// </summary>
        /// <param name="yesno">YesNo value to convert</param>
        /// <returns>String representing the value, if possible</returns>
        public static string LongName(this YesNo yesno)
        {
            switch (yesno)
            {
                case YesNo.No:
                    return "No";
                case YesNo.Yes:
                    return "Yes";
                default:
                case YesNo.NULL:
                    return "Yes/No";
            }
        }

        #endregion

        #region Convert to Short Name

        /// <summary>
        /// Short name method cache
        /// </summary>
        private static readonly ConcurrentDictionary<Type, MethodInfo> ShortNameMethods = new ConcurrentDictionary<Type, MethodInfo>();

        /// <summary>
        /// Get the short string representation of a generic enumerable value
        /// </summary>
        /// <param name="value">Enum value to convert</param>
        /// <returns>String representation of that value if possible, empty string on error</returns>
        public static string GetShortName(Enum value)
        {
            try
            {
                var sourceType = value.GetType();
                sourceType = Nullable.GetUnderlyingType(sourceType) ?? sourceType;

                if (!ShortNameMethods.TryGetValue(sourceType, out MethodInfo method))
                {
                    method = typeof(EnumConverter).GetMethod("ShortName", new[] { typeof(Nullable<>).MakeGenericType(sourceType) });
                    ShortNameMethods.TryAdd(sourceType, method);
                }

                if (method != null)
                    return method.Invoke(null, new[] { value }) as string;
                else
                    return string.Empty;
            }
            catch
            {
                // Converter is not implemented for the given type
                return string.Empty;
            }
        }

        /// <summary>
        /// Get the short string representation of the KnownSystem enum values
        /// </summary>
        /// <param name="sys">KnownSystem value to convert</param>
        /// <returns>Short string representing the value, if possible</returns>
        public static string ShortName(this KnownSystem? sys)
        {
            switch (sys)
            {
                #region Consoles

                case KnownSystem.AtariJaguarCD:
                    return "jaguar";
                case KnownSystem.BandaiPlaydiaQuickInteractiveSystem:
                    return "playdia";
                case KnownSystem.BandaiApplePippin:
                    return "pippin";
                case KnownSystem.CommodoreAmigaCD32:
                    return "cd32";
                case KnownSystem.EnvizionsEVOSmartConsole:
                    return "evosc";
                case KnownSystem.FujitsuFMTownsMarty:
                    return "fmtm";
                case KnownSystem.CommodoreAmigaCDTV:
                    return "cdtv";
                case KnownSystem.HasbroVideoNow:
                    return "videonow";
                case KnownSystem.HasbroVideoNowColor:
                    return "videonowcolor";
                case KnownSystem.HasbroVideoNowJr:
                    return "videonowjr";
                case KnownSystem.HasbroVideoNowXP:
                    return "videonowxp";
                case KnownSystem.MattelFisherPriceiXL:
                    return "ixl";
                case KnownSystem.MattelHyperscan:
                    return "hyperscan";
                case KnownSystem.MicrosoftXBOX:
                    return "xbox";
                case KnownSystem.MicrosoftXBOX360:
                    return "x360";
                case KnownSystem.MicrosoftXBOXOne:
                    return "xbone";
                case KnownSystem.MicrosoftXboxSeriesXS:
                    return "xbseries";
                case KnownSystem.NECPCEngineTurboGrafxCD:
                    return "pcecd";
                case KnownSystem.NECPCFX:
                    return "pcfx";
                case KnownSystem.NintendoGameCube:
                    return "gc";
                case KnownSystem.NintendoSonySuperNESCDROMSystem:
                    return "snescd";
                case KnownSystem.NintendoWii:
                    return "wii";
                case KnownSystem.NintendoWiiU:
                    return "wiiu";
                case KnownSystem.Panasonic3DOInteractiveMultiplayer:
                    return "3do";
                case KnownSystem.PhilipsCDi:
                    return "cdi";
                case KnownSystem.PioneerLaserActive:
                    return "laseractive";
                case KnownSystem.SegaCDMegaCD:
                    return "mcd";
                case KnownSystem.SegaDreamcast:
                    return "dc";
                case KnownSystem.SegaSaturn:
                    return "saturn";
                case KnownSystem.SNKNeoGeoCD:
                    return "ngcd";
                case KnownSystem.SonyPlayStation:
                    return "psx";
                case KnownSystem.SonyPlayStation2:
                    return "ps2";
                case KnownSystem.SonyPlayStation3:
                    return "ps3";
                case KnownSystem.SonyPlayStation4:
                    return "ps4";
                case KnownSystem.SonyPlayStation5:
                    return "ps5";
                case KnownSystem.SonyPlayStationPortable:
                    return "psp";
                case KnownSystem.TandyMemorexVisualInformationSystem:
                    return "vis";
                case KnownSystem.VMLabsNuon:
                    return "nuon";
                case KnownSystem.VTechVFlashVSmilePro:
                    return "vflash";
                case KnownSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem:
                    return "gamewave";

                #endregion

                #region Computers

                case KnownSystem.AcornArchimedes:
                    return "archimedes";
                case KnownSystem.AppleMacintosh:
                    return "mac";
                case KnownSystem.CommodoreAmiga:
                    return "amiga";
                case KnownSystem.FujitsuFMTowns:
                    return "fmtowns";
                case KnownSystem.IBMPCCompatible:
                    return "ibm";
                case KnownSystem.NECPC88:
                    return "pc88";
                case KnownSystem.NECPC98:
                    return "pc98";
                case KnownSystem.SharpX68000:
                    return "x68k";

                #endregion

                #region Arcade

                case KnownSystem.AmigaCUBOCD32:
                    return "cubo";
                case KnownSystem.AmericanLaserGames3DO:
                    return "alg 3do";
                case KnownSystem.Atari3DO:
                    return "atari 3do";
                case KnownSystem.Atronic:
                    return "atronic";
                case KnownSystem.AUSCOMSystem1:
                    return "auscom";
                case KnownSystem.BallyGameMagic:
                    return "game magic";
                case KnownSystem.CapcomCPSystemIII:
                    return "cps3";
                case KnownSystem.funworldPhotoPlay:
                    return "fpp";
                case KnownSystem.GlobalVRVarious:
                    return "globalvr";
                case KnownSystem.GlobalVRVortek:
                    return "vortek";
                case KnownSystem.GlobalVRVortekV3:
                    return "vortek v3";
                case KnownSystem.ICEPCHardware:
                    return "ice";
                case KnownSystem.IncredibleTechnologiesEagle:
                    return "eagle";
                case KnownSystem.IncredibleTechnologiesVarious:
                    return "itpc";
                case KnownSystem.KonamieAmusement:
                    return "e-amusement";
                case KnownSystem.KonamiFirebeat:
                    return "firebeat";
                case KnownSystem.KonamiGVSystem:
                    return "gv system";
                case KnownSystem.KonamiM2:
                    return "konami m2";
                case KnownSystem.KonamiPython:
                    return "python";
                case KnownSystem.KonamiPython2:
                    return "python 2";
                case KnownSystem.KonamiSystem573:
                    return "system 573";
                case KnownSystem.KonamiTwinkle:
                    return "twinkle";
                case KnownSystem.KonamiVarious:
                    return "konami pc";
                case KnownSystem.MeritIndustriesBoardwalk:
                    return "boardwalk";
                case KnownSystem.MeritIndustriesMegaTouchForce:
                    return "megatouch force";
                case KnownSystem.MeritIndustriesMegaTouchION:
                    return "megatouch ion";
                case KnownSystem.MeritIndustriesMegaTouchMaxx:
                    return "megatouch maxx";
                case KnownSystem.MeritIndustriesMegaTouchXL:
                    return "megatouch xl";
                case KnownSystem.NamcoCapcomSystem256:
                    return "system 256";
                case KnownSystem.NamcoCapcomTaitoSystem246:
                    return "system 246";
                case KnownSystem.NamcoSegaNintendoTriforce:
                    return "triforce";
                case KnownSystem.NamcoSystem12:
                    return "system 12";
                case KnownSystem.NamcoSystem357:
                    return "system 357";
                case KnownSystem.NewJatreCDi:
                    return "new jatre cdi";
                case KnownSystem.NichibutsuHighRateSystem:
                    return "nichibutsu hrs";
                case KnownSystem.NichibutsuSuperCD:
                    return "nichibutsu scd";
                case KnownSystem.NichibutsuXRateSystem:
                    return "nichibutsu xrs";
                case KnownSystem.PanasonicM2:
                    return "panasonic m2";
                case KnownSystem.PhotoPlayVarious:
                    return "photoplay";
                case KnownSystem.RawThrillsVarious:
                    return "raw thrills";
                case KnownSystem.SegaChihiro:
                    return "chihiro";
                case KnownSystem.SegaEuropaR:
                    return "europar";
                case KnownSystem.SegaLindbergh:
                    return "lindbergh";
                case KnownSystem.SegaNaomi:
                    return "naomi";
                case KnownSystem.SegaNaomi2:
                    return "naomi 2";
                case KnownSystem.SegaNu:
                    return "nu";
                case KnownSystem.SegaRingEdge:
                    return "ringedge";
                case KnownSystem.SegaRingEdge2:
                    return "ringedge 2";
                case KnownSystem.SegaRingWide:
                    return "ringwide";
                case KnownSystem.SegaTitanVideo:
                    return "stv";
                case KnownSystem.SegaSystem32:
                    return "system 32";
                case KnownSystem.SeibuCATSSystem:
                    return "seibu cats";
                case KnownSystem.TABAustriaQuizard:
                    return "quizard";
                case KnownSystem.TsunamiTsuMoMultiGameMotionSystem:
                    return "tsumo";

                #endregion

                #region Others

                case KnownSystem.AudioCD:
                    return "audio";
                case KnownSystem.BDVideo:
                    return "bd-video";
                case KnownSystem.DVDAudio:
                    return "dvd-audio";
                case KnownSystem.DVDVideo:
                    return "dvd-video";
                case KnownSystem.EnhancedCD:
                    return "enhanced cd";
                case KnownSystem.HDDVDVideo:
                    return "hddvd-video";
                case KnownSystem.NavisoftNaviken21:
                    return "naviken";
                case KnownSystem.PalmOS:
                    return "palmos";
                case KnownSystem.PhotoCD:
                    return "photo cd";
                case KnownSystem.PlayStationGameSharkUpdates:
                    return "gameshark";
                case KnownSystem.PocketPC:
                    return "ppc";
                case KnownSystem.RainbowDisc:
                    return "rainbow";
                case KnownSystem.SegaPrologue21:
                    return "pl21";
                case KnownSystem.SuperAudioCD:
                    return "sacd";
                case KnownSystem.TaoiKTV:
                    return "iktv";
                case KnownSystem.TomyKissSite:
                    return "kiss-site";
                case KnownSystem.VideoCD:
                    return "vcd";

                #endregion

                case KnownSystem.NONE:
                default:
                    return "unknown";
            }
        }

        /// <summary>
        /// Get the short string representation of the MediaType enum values
        /// </summary>
        /// <param name="type">MediaType value to convert</param>
        /// <returns>Short string representing the value, if possible</returns>
        public static string ShortName(this MediaType? type)
        {
            switch (type)
            {
                #region Punched Media

                case MediaType.ApertureCard:
                    return "aperture";
                case MediaType.JacquardLoomCard:
                    return "jacquard loom card";
                case MediaType.MagneticStripeCard:
                    return "magnetic stripe";
                case MediaType.OpticalPhonecard:
                    return "optical phonecard";
                case MediaType.PunchedCard:
                    return "punchcard";
                case MediaType.PunchedTape:
                    return "punchtape";

                #endregion

                #region Tape

                case MediaType.OpenReel:
                    return "open reel";
                case MediaType.DataCartridge:
                    return "data cartridge";
                case MediaType.Cassette:
                    return "cassette";

                #endregion

                #region Disc / Disc

                case MediaType.BluRay:
                    return "bdrom";
                case MediaType.CDROM:
                    return "cdrom";
                case MediaType.DVD:
                    return "dvd";
                case MediaType.FloppyDisk:
                    return "fd";
                case MediaType.Floptical:
                    return "floptical";
                case MediaType.GDROM:
                    return "gdrom";
                case MediaType.HDDVD:
                    return "hddvd";
                case MediaType.HardDisk:
                    return "hdd";
                case MediaType.IomegaBernoulliDisk:
                    return "bernoulli";
                case MediaType.IomegaJaz:
                    return "jaz";
                case MediaType.IomegaZip:
                    return "zip";
                case MediaType.LaserDisc:
                    return "ldrom";
                case MediaType.Nintendo64DD:
                    return "64dd";
                case MediaType.NintendoFamicomDiskSystem:
                    return "fds";
                case MediaType.NintendoGameCubeGameDisc:
                    return "gc";
                case MediaType.NintendoWiiOpticalDisc:
                    return "wii";
                case MediaType.NintendoWiiUOpticalDisc:
                    return "wiiu";
                case MediaType.UMD:
                    return "umd";

                #endregion

                // Unsorted Formats
                case MediaType.Cartridge:
                    return "cart";
                case MediaType.CED:
                    return "ced";

                case MediaType.NONE:
                default:
                    return "unknown";
            }
        }

        #endregion

        #region Convert From String

        /// <summary>
        /// Get the InternalProgram enum value for a given string
        /// </summary>
        /// <param name="internalProgram">String value to convert</param>
        /// <returns>InternalProgram represented by the string, if possible</returns>
        public static InternalProgram ToInternalProgram(string internalProgram)
        {
            switch (internalProgram.ToLowerInvariant())
            {
                // Dumping support
                case "aaru":
                case "chef":
                case "dichef":
                case "discimagechef":
                    return InternalProgram.Aaru;
                case "creator":
                case "dic":
                case "dicreator":
                case "discimagecreator":
                    return InternalProgram.DiscImageCreator;
                case "dd":
                    return InternalProgram.DD;

                // Verification support only
                case "cleanrip":
                case "cr":
                    return InternalProgram.CleanRip;
                case "dc":
                case "dcd":
                case "dcdumper":
                    return InternalProgram.DCDumper;
                case "uic":
                case "umd":
                case "umdcreator":
                case "umdimagecreator":
                    return InternalProgram.UmdImageCreator;

                default:
                    return InternalProgram.NONE;
            }
        }

        /// <summary>
        /// Get the KnownSystem enum value for a given string
        /// </summary>
        /// <param name="sys">String value to convert</param>
        /// <returns>KnownSystem represented by the string, if possible</returns>
        public static KnownSystem? ToKnownSystem(string sys)
        {
            switch (sys.ToLowerInvariant())
            {
                #region Consoles

                case "jaguar":
                case "jagcd":
                case "jaguarcd":
                case "jaguar cd":
                case "atarijaguar":
                case "atarijagcd":
                case "atarijaguarcd":
                case "atari jaguar cd":
                    return KnownSystem.AtariJaguarCD;
                case "playdia":
                case "playdiaqis":
                case "playdiaquickinteractivesystem":
                case "bandaiplaydia":
                case "bandaiplaydiaquickinteractivesystem":
                case "bandai playdia quick interactive system":
                    return KnownSystem.BandaiPlaydiaQuickInteractiveSystem;
                case "pippin":
                case "bandaipippin":
                case "bandai pippin":
                case "applepippin":
                case "apple pippin":
                case "bandaiapplepippin":
                case "bandai apple pippin":
                case "bandai / apple pippin":
                    return KnownSystem.BandaiApplePippin;
                case "cd32":
                case "amigacd32":
                case "amiga cd32":
                case "commodoreamigacd32":
                case "commodore amiga cd32":
                    return KnownSystem.CommodoreAmigaCD32;
                case "cdtv":
                case "amigacdtv":
                case "amiga cdtv":
                case "commodoreamigacdtv":
                case "commodore amiga cdtv":
                    return KnownSystem.CommodoreAmigaCDTV;
                case "evosc":
                case "evo sc":
                case "evosmartconsole":
                case "evo smart console":
                case "envizionsevosc":
                case "envizion evo sc":
                case "envizionevosmartconsole":
                case "envizion evo smart console":
                    return KnownSystem.EnvizionsEVOSmartConsole;
                case "fmtm":
                case "fmtownsmarty":
                case "fm towns marty":
                case "fujitsufmtownsmarty":
                case "fujitsu fm towns marty":
                    return KnownSystem.FujitsuFMTownsMarty;
                case "videonow":
                case "hasbrovideonow":
                case "hasbro videonow":
                    return KnownSystem.HasbroVideoNow;
                case "videonowcolor":
                case "videonow color":
                case "hasbrovideonowcolor":
                case "hasbro videonow color":
                    return KnownSystem.HasbroVideoNowColor;
                case "videonowjr":
                case "videonow jr":
                case "hasbrovideonowjr":
                case "hasbro videonow jr":
                    return KnownSystem.HasbroVideoNowJr;
                case "videonowxp":
                case "videonow xp":
                case "hasbrovideonowxp":
                case "hasbro videonow xp":
                    return KnownSystem.HasbroVideoNowXP;
                case "ixl":
                case "mattelixl":
                case "mattel ixl":
                case "fisherpriceixl":
                case "fisher price ixl":
                case "fisher-price ixl":
                case "fisherprice ixl":
                case "mattelfisherpriceixl":
                case "mattel fisher price ixl":
                case "mattelfisherprice ixl":
                case "mattel fisherprice ixl":
                case "mattel fisher-price ixl":
                    return KnownSystem.MattelFisherPriceiXL;
                case "hyperscan":
                case "mattelhyperscan":
                case "mattel hyperscan":
                    return KnownSystem.MattelHyperscan;
                case "xbox":
                case "microsoftxbox":
                case "microsoft xbox":
                    return KnownSystem.MicrosoftXBOX;
                case "x360":
                case "xbox360":
                case "microsoftx360":
                case "microsoftxbox360":
                case "microsoft x360":
                case "microsoft xbox 360":
                    return KnownSystem.MicrosoftXBOX360;
                case "xb1":
                case "xbone":
                case "xboxone":
                case "microsoftxbone":
                case "microsoftxboxone":
                case "microsoft xbone":
                case "microsoft xbox one":
                    return KnownSystem.MicrosoftXBOXOne;
                case "xbs":
                case "xbseries":
                case "xbseriess":
                case "xbseriesx":
                case "xbseriessx":
                case "xboxseries":
                case "xboxseriess":
                case "xboxseriesx":
                case "xboxseriesxs":
                case "microsoftxboxseries":
                case "microsoftxboxseriess":
                case "microsoftxboxseriesx":
                case "microsoftxboxseriesxs":
                case "microsoft xbox series":
                case "microsoft xbox series s":
                case "microsoft xbox series x":
                case "microsoft xbox series x and s":
                    return KnownSystem.MicrosoftXboxSeriesXS;
                case "pcecd":
                case "pce-cd":
                case "tgcd":
                case "tg-cd":
                case "necpcecd":
                case "nectgcd":
                case "nec pc-engine cd":
                case "nec turbografx cd":
                case "nec pc-engine / turbografx cd":
                    return KnownSystem.NECPCEngineTurboGrafxCD;
                case "pcfx":
                case "pc-fx":
                case "pcfxga":
                case "pc-fxga":
                case "necpcfx":
                case "necpcfxga":
                case "nec pc-fx":
                case "nec pc-fxga":
                case "nec pc-fx / pc-fxga":
                    return KnownSystem.NECPCFX;
                case "gc":
                case "gamecube":
                case "ngc":
                case "nintendogamecube":
                case "nintendo gamecube":
                    return KnownSystem.NintendoGameCube;
                case "snescd":
                case "snes cd":
                case "snes-cd":
                case "supernescd":
                case "super nes cd":
                case "super nes-cd":
                case "supernintendocd":
                case "super nintendo cd":
                case "super nintendo-cd":
                case "nintendosnescd":
                case "nintendo snes cd":
                case "nintendosnes-cd":
                case "nintendosupernescd":
                case "nintendo super nes cd":
                case "nintendo super nes-cd":
                case "nintendosupernintendocd":
                case "nintendo super nintendo cd":
                case "nintendo super nintendo-cd":
                case "sonysnescd":
                case "sony snes cd":
                case "sonysnes-cd":
                case "sonysupernescd":
                case "sony super nes cd":
                case "sony super nes-cd":
                case "sonysupernintendocd":
                case "sony super nintendo cd":
                case "sony super nintendo-cd":
                    return KnownSystem.NintendoSonySuperNESCDROMSystem;
                case "wii":
                case "nintendowii":
                case "nintendo wii":
                    return KnownSystem.NintendoWii;
                case "wiiu":
                case "wii u":
                case "nintendowiiu":
                case "nintendo wii u":
                    return KnownSystem.NintendoWiiU;
                case "3do":
                case "3do interactive multiplayer":
                case "panasonic3do":
                case "panasonic 3do":
                case "panasonic 3do interactive multiplayer":
                    return KnownSystem.Panasonic3DOInteractiveMultiplayer;
                case "cdi":
                case "cd-i":
                case "philipscdi":
                case "philips cdi":
                case "philips cd-i":
                    return KnownSystem.PhilipsCDi;
                case "laseractive":
                case "pioneerlaseractive":
                case "pioneer laseractive":
                    return KnownSystem.PioneerLaserActive;
                case "scd":
                case "mcd":
                case "smcd":
                case "segacd":
                case "megacd":
                case "segamegacd":
                case "sega cd":
                case "mega cd":
                case "sega cd / mega cd":
                    return KnownSystem.SegaCDMegaCD;
                case "dc":
                case "sdc":
                case "dreamcast":
                case "segadreamcast":
                case "sega dreamcast":
                    return KnownSystem.SegaDreamcast;
                case "saturn":
                case "segasaturn":
                case "sega saturn":
                    return KnownSystem.SegaSaturn;
                case "ngcd":
                case "neogeocd":
                case "neogeo cd":
                case "neo geo cd":
                case "snk ngcd":
                case "snk neogeo cd":
                case "snk neo geo cd":
                    return KnownSystem.SNKNeoGeoCD;
                case "ps1":
                case "psx":
                case "playstation":
                case "sonyps1":
                case "sony ps1":
                case "sonypsx":
                case "sony psx":
                case "sonyplaystation":
                case "sony playstation":
                    return KnownSystem.SonyPlayStation;
                case "ps2":
                case "playstation2":
                case "playstation 2":
                case "sonyps2":
                case "sony ps2":
                case "sonyplaystation2":
                case "sony playstation 2":
                    return KnownSystem.SonyPlayStation2;
                case "ps3":
                case "playstation3":
                case "playstation 3":
                case "sonyps3":
                case "sony ps3":
                case "sonyplaystation3":
                case "sony playstation 3":
                    return KnownSystem.SonyPlayStation3;
                case "ps4":
                case "playstation4":
                case "playstation 4":
                case "sonyps4":
                case "sony ps4":
                case "sonyplaystation4":
                case "sony playstation 4":
                    return KnownSystem.SonyPlayStation4;
                case "ps5":
                case "playstation5":
                case "playstation 5":
                case "sonyps5":
                case "sony ps5":
                case "sonyplaystation5":
                case "sony playstation 5":
                    return KnownSystem.SonyPlayStation5;
                case "psp":
                case "playstationportable":
                case "playstation portable":
                case "sonypsp":
                case "sony psp":
                case "sonyplaystationportable":
                case "sony playstation portable":
                    return KnownSystem.SonyPlayStationPortable;
                case "vis":
                case "tandyvis":
                case "tandy vis":
                case "tandyvisualinformationsystem":
                case "tandy visual information system":
                case "memorexvis":
                case "memorex vis":
                case "memorexvisualinformationsystem":
                case "memorex visual information sytem":
                case "tandy / memorex visual information system":
                    return KnownSystem.TandyMemorexVisualInformationSystem;
                case "nuon":
                case "vmlabsnuon":
                case "vm labs nuon":
                    return KnownSystem.VMLabsNuon;
                case "vflash":
                case "vsmile":
                case "vsmilepro":
                case "vsmile pro":
                case "v.flash":
                case "v.smile":
                case "v.smilepro":
                case "v.smile pro":
                case "vtechvflash":
                case "vtech vflash":
                case "vtech v.flash":
                case "vtechvsmile":
                case "vtech vsmile":
                case "vtech v.smile":
                case "vtechvsmilepro":
                case "vtech vsmile pro":
                case "vtech v.smile pro":
                case "vtech v.flash - v.smile pro":
                    return KnownSystem.VTechVFlashVSmilePro;
                case "gamewave":
                case "game wave":
                case "zapit":
                case "zapitgamewave":
                case "zapit game wave":
                case "zapit games game wave family entertainment system":
                    return KnownSystem.ZAPiTGamesGameWaveFamilyEntertainmentSystem;

                #endregion

                #region Computers

                case "acorn":
                case "archimedes":
                case "acornarchimedes":
                case "acorn archimedes":
                    return KnownSystem.AcornArchimedes;
                case "apple":
                case "mac":
                case "applemac":
                case "macintosh":
                case "applemacintosh":
                case "apple mac":
                case "apple macintosh":
                    return KnownSystem.AppleMacintosh;
                case "amiga":
                case "commodoreamiga":
                case "commodore amiga":
                    return KnownSystem.CommodoreAmiga;
                case "fmtowns":
                case "fmt":
                case "fm towns":
                case "fujitsufmtowns":
                case "fujitsu fm towns":
                case "fujitsu fm towns series":
                    return KnownSystem.FujitsuFMTowns;
                case "ibm":
                case "ibmpc":
                case "pc":
                case "ibm pc":
                case "ibm pc compatible":
                    return KnownSystem.IBMPCCompatible;
                case "pc88":
                case "pc-88":
                case "necpc88":
                case "nec pc88":
                case "nec pc-88":
                    return KnownSystem.NECPC88;
                case "pc98":
                case "pc-98":
                case "necpc98":
                case "nec pc98":
                case "nec pc-98":
                    return KnownSystem.NECPC98;
                case "x68k":
                case "x68000":
                case "sharpx68k":
                case "sharp x68k":
                case "sharpx68000":
                case "sharp x68000":
                    return KnownSystem.SharpX68000;

                #endregion

                #region Arcade

                case "cubo":
                case "cubocd32":
                case "cubo cd32":
                case "amigacubocd32":
                case "amiga cubo cd32":
                    return KnownSystem.AmigaCUBOCD32;
                case "alg3do":
                case "alg 3do":
                case "americanlasergames3do":
                case "american laser games 3do":
                    return KnownSystem.AmericanLaserGames3DO;
                case "atari3do":
                case "atari 3do":
                    return KnownSystem.Atari3DO;
                case "atronic":
                    return KnownSystem.Atronic;
                case "auscom":
                case "auscomsystem1":
                case "auscom system 1":
                    return KnownSystem.AUSCOMSystem1;
                case "gamemagic":
                case "game magic":
                case "ballygamemagic":
                case "bally game magic":
                    return KnownSystem.BallyGameMagic;
                case "cps3":
                case "cpsiii":
                case "cps 3":
                case "cp system 3":
                case "cp system iii":
                case "capcomcps3":
                case "capcomcpsiii":
                case "capcom cps 3":
                case "capcom cps iii":
                case "capcom cp system 3":
                case "capcom cp system iii":
                    return KnownSystem.CapcomCPSystemIII;
                case "fpp":
                case "funworldphotoplay":
                case "funworld photoplay":
                case "funworld photo play":
                    return KnownSystem.funworldPhotoPlay;
                case "globalvr":
                case "global vr":
                case "global vr pc-based systems":
                    return KnownSystem.GlobalVRVarious;
                case "vortek":
                case "globalvrvortek":
                case "global vr vortek":
                    return KnownSystem.GlobalVRVortek;
                case "vortekv3":
                case "vortek v3":
                case "globalvrvortekv3":
                case "global vr vortek v3":
                    return KnownSystem.GlobalVRVortekV3;
                case "ice":
                case "icepc":
                case "ice pc":
                case "ice pc-based hardware":
                    return KnownSystem.ICEPCHardware;
                case "iteagle":
                case "eagle":
                case "incredible technologies eagle":
                    return KnownSystem.IncredibleTechnologiesEagle;
                case "itpc":
                case "incredible technologies pc-based systems":
                    return KnownSystem.IncredibleTechnologiesVarious;
                case "eamusement":
                case "e-amusement":
                case "konamieamusement":
                case "konami eamusement":
                case "konamie-amusement":
                case "konami e-amusement":
                    return KnownSystem.KonamieAmusement;
                case "firebeat":
                case "konamifirebeat":
                case "konami firebeat":
                    return KnownSystem.KonamiFirebeat;
                case "gvsystem":
                case "gv system":
                case "konamigvsystem":
                case "konami gv system":
                    return KnownSystem.KonamiGVSystem;
                case "konamim2":
                case "konami m2":
                    return KnownSystem.KonamiM2;
                case "python":
                case "konamipython":
                case "konami python":
                    return KnownSystem.KonamiPython;
                case "python2":
                case "python 2":
                case "konamipython2":
                case "konami python 2":
                    return KnownSystem.KonamiPython2;
                case "system573":
                case "system 573":
                case "konamisystem573":
                case "konami system 573":
                    return KnownSystem.KonamiSystem573;
                case "twinkle":
                case "konamitwinkle":
                case "konami twinkle":
                    return KnownSystem.KonamiTwinkle;
                case "konamipc":
                case "konami pc":
                case "konami pc-based systems":
                    return KnownSystem.KonamiVarious;
                case "boardwalk":
                case "meritindustriesboardwalk":
                case "merit industries boardwalk":
                    return KnownSystem.MeritIndustriesBoardwalk;
                case "megatouchforce":
                case "megatouch force":
                case "meritindustriesmegatouchforce":
                case "merit industries megatouch force":
                    return KnownSystem.MeritIndustriesMegaTouchForce;
                case "megatouchion":
                case "megatouch ion":
                case "meritindustriesmegatouchion":
                case "merit industries megatouch ion":
                    return KnownSystem.MeritIndustriesMegaTouchION;
                case "megatouchmaxx":
                case "megatouch maxx":
                case "meritindustriesmegatouchmaxx":
                case "merit industries megatouch maxx":
                    return KnownSystem.MeritIndustriesMegaTouchMaxx;
                case "megatouchxl":
                case "megatouch xl":
                case "meritindustriesmegatouchxl":
                case "merit industries megatouch xl":
                    return KnownSystem.MeritIndustriesMegaTouchXL;
                case "system256":
                case "system 256":
                case "supersystem256":
                case "super system 256":
                case "namcosystem256":
                case "namco system 256":
                case "namcosupersystem256":
                case "namco super system 256":
                case "capcomsystem256":
                case "capcom system 256":
                case "capcomsupersystem256":
                case "capcom super system 256":
                case "namco / capcom system 256/super system 256":
                    return KnownSystem.NamcoCapcomSystem256;
                case "system246":
                case "system 246":
                case "namcosystem246":
                case "namco system 246":
                case "capcomsystem246":
                case "capcom system 246":
                case "taitosystem246":
                case "taito system 246":
                case "namco / capcom / taito system 246":
                    return KnownSystem.NamcoCapcomTaitoSystem246;
                case "triforce":
                case "namcotriforce":
                case "namco triforce":
                case "segatriforce":
                case "sega triforce":
                case "nintendotriforce":
                case "nintendo triforce":
                case "namco / sega / nintendo triforce":
                    return KnownSystem.NamcoSegaNintendoTriforce;
                case "system12":
                case "system 12":
                case "namcosystem12":
                case "namco system 12":
                    return KnownSystem.NamcoSystem12;
                case "system357":
                case "system 357":
                case "namcosystem357":
                case "namco system 357":
                    return KnownSystem.NamcoSystem357;
                case "newjatrecdi":
                case "new jatre cdi":
                case "new jatre cd-i":
                    return KnownSystem.NewJatreCDi;
                case "hrs":
                case "highratesytem":
                case "high rate system":
                case "nichibutsuhrs":
                case "nichibutsu hrs":
                case "nichibutsu high rate system":
                    return KnownSystem.NichibutsuHighRateSystem;
                case "supercd":
                case "super cd":
                case "nichibutsuscd":
                case "nichibutsu scd":
                case "nichibutsusupercd":
                case "nichibutsu supercd":
                case "nichibutsu super cd":
                    return KnownSystem.NichibutsuSuperCD;
                case "xrs":
                case "xratesystem":
                case "x-rate system":
                case "nichibutsuxrs":
                case "nichibutsu xrs":
                case "nichibutsu x-rate system":
                    return KnownSystem.NichibutsuXRateSystem;
                case "panasonicm2":
                case "panasonic m2":
                    return KnownSystem.PanasonicM2;
                case "photoplay":
                case "photoplaypc":
                case "photoplay pc":
                case "photoplay pc-based systems":
                    return KnownSystem.PhotoPlayVarious;
                case "rawthrills":
                case "raw thrills":
                case "raw thrills pc-based systems":
                    return KnownSystem.RawThrillsVarious;
                case "chihiro":
                case "segachihiro":
                case "sega chihiro":
                    return KnownSystem.SegaChihiro;
                case "europar":
                case "europa-r":
                case "segaeuropar":
                case "sega europar":
                case "sega europa-r":
                    return KnownSystem.SegaEuropaR;
                case "lindbergh":
                case "segalindbergh":
                case "sega lindbergh":
                    return KnownSystem.SegaLindbergh;
                case "naomi":
                case "seganaomi":
                case "sega naomi":
                    return KnownSystem.SegaNaomi;
                case "naomi2":
                case "naomi 2":
                case "seganaomi2":
                case "sega naomi 2":
                    return KnownSystem.SegaNaomi2;
                case "nu":
                case "seganu":
                case "sega nu":
                    return KnownSystem.SegaNu;
                case "ringedge":
                case "segaringedge":
                case "sega ringedge":
                    return KnownSystem.SegaRingEdge;
                case "ringedge2":
                case "ringedge 2":
                case "segaringedge2":
                case "sega ringedge 2":
                    return KnownSystem.SegaRingEdge2;
                case "ringwide":
                case "segaringwide":
                case "sega ringwide":
                    return KnownSystem.SegaRingWide;
                case "stv":
                case "titanvideo":
                case "titan video":
                case "segatitanvideo":
                case "sega titan video":
                    return KnownSystem.SegaTitanVideo;
                case "system32":
                case "system 32":
                case "segasystem32":
                case "sega system 32":
                    return KnownSystem.SegaSystem32;
                case "cats":
                case "seibucats":
                case "seibu cats":
                case "seibu cats system":
                    return KnownSystem.SeibuCATSSystem;
                case "quizard":
                case "tabaustriaquizard":
                case "tab-austria quizard":
                    return KnownSystem.TABAustriaQuizard;
                case "tsumo":
                case "tsunamitsumo":
                case "tsunami tsumo":
                case "tsunami tsumo multi-game motion system":
                    return KnownSystem.TsunamiTsuMoMultiGameMotionSystem;

                #endregion

                #region Others

                case "audio":
                case "audiocd":
                case "audio cd":
                    return KnownSystem.AudioCD;
                case "bdvideo":
                case "bd-video":
                case "blurayvideo":
                case "bluray video":
                    return KnownSystem.BDVideo;
                case "dvda":
                case "dvdaudio":
                case "dvd-audio":
                    return KnownSystem.DVDAudio;
                case "dvd":
                case "dvdv":
                case "dvdvideo":
                case "dvd-video":
                    return KnownSystem.DVDVideo;
                case "enhancedcd":
                case "enhanced cd":
                case "enhancedcdrom":
                case "enhanced cdrom":
                case "enhanced cd-rom":
                    return KnownSystem.EnhancedCD;
                case "hddvd":
                case "hddvdv":
                case "hddvdvideo":
                case "hddvd-video":
                case "hd-dvd-video":
                    return KnownSystem.HDDVDVideo;
                case "naviken":
                case "naviken21":
                case "naviken 2.1":
                case "navisoftnaviken":
                case "navisoft naviken":
                case "navisoftnaviken21":
                case "navisoft naviken 2.1":
                    return KnownSystem.NavisoftNaviken21;
                case "palm":
                case "palmos":
                    return KnownSystem.PalmOS;
                case "photo":
                case "photocd":
                case "photo cd":
                    return KnownSystem.PhotoCD;
                case "gameshark":
                case "psgameshark":
                case "ps gameshark":
                case "playstationgameshark":
                case "playstation gameshark":
                case "playstation gameshark updates":
                    return KnownSystem.PlayStationGameSharkUpdates;
                case "pocketpc":
                case "pocket pc":
                case "ppc":
                    return KnownSystem.PocketPC;
                case "rainbow":
                case "rainbowdisc":
                case "rainbow disc":
                    return KnownSystem.RainbowDisc;
                case "pl21":
                case "prologue21":
                case "prologue 21":
                case "segaprologue21":
                case "sega prologue21":
                case "sega prologue 21":
                    return KnownSystem.SegaPrologue21;
                case "sacd":
                case "superaudiocd":
                case "super audio cd":
                    return KnownSystem.SuperAudioCD;
                case "iktv":
                case "taoiktv":
                case "tao iktv":
                    return KnownSystem.TaoiKTV;
                case "kisssite":
                case "kiss-site":
                case "tomykisssite":
                case "tomy kisssite":
                case "tomy kiss-site":
                    return KnownSystem.TomyKissSite;
                case "vcd":
                case "videocd":
                case "video cd":
                    return KnownSystem.VideoCD;

                #endregion

                default:
                    return KnownSystem.NONE;
            }
        }

        /// <summary>
        /// Get the MediaType enum value for a given string
        /// </summary>
        /// <param name="type">String value to convert</param>
        /// <returns>MediaType represented by the string, if possible</returns>
        public static MediaType ToMediaType(string type)
        {
            switch (type.ToLowerInvariant())
            {
                #region Punched Media

                case "aperture":
                case "aperturecard":
                case "aperture card":
                    return MediaType.ApertureCard;
                case "jacquardloom":
                case "jacquardloomcard":
                case "jacquard loom card":
                    return MediaType.JacquardLoomCard;
                case "magneticstripe":
                case "magneticstripecard":
                case "magnetic stripe card":
                    return MediaType.MagneticStripeCard;
                case "opticalphone":
                case "opticalphonecard":
                case "optical phonecard":
                    return MediaType.OpticalPhonecard;
                case "punchcard":
                case "punchedcard":
                case "punched card":
                    return MediaType.PunchedCard;
                case "punchtape":
                case "punchedtape":
                case "punched tape":
                    return MediaType.PunchedTape;

                #endregion

                #region Tape

                case "openreel":
                case "openreeltape":
                case "open reel tape":
                    return MediaType.OpenReel;
                case "datacart":
                case "datacartridge":
                case "datatapecartridge":
                case "data tape cartridge":
                    return MediaType.DataCartridge;
                case "cassette":
                case "cassettetape":
                case "cassette tape":
                    return MediaType.Cassette;

                #endregion

                #region Disc / Disc

                case "bd":
                case "bdrom":
                case "bd-rom":
                case "bluray":
                    return MediaType.BluRay;
                case "cd":
                case "cdrom":
                case "cd-rom":
                    return MediaType.CDROM;
                case "dvd":
                case "dvd5":
                case "dvd-5":
                case "dvd9":
                case "dvd-9":
                case "dvdrom":
                case "dvd-rom":
                    return MediaType.DVD;
                case "fd":
                case "floppy":
                case "floppydisk":
                case "floppy disk":
                case "floppy diskette":
                    return MediaType.FloppyDisk;
                case "floptical":
                    return MediaType.Floptical;
                case "gd":
                case "gdrom":
                case "gd-rom":
                    return MediaType.GDROM;
                case "hddvd":
                case "hd-dvd":
                case "hddvdrom":
                case "hd-dvd-rom":
                    return MediaType.HDDVD;
                case "hdd":
                case "harddisk":
                case "hard disk":
                    return MediaType.HardDisk;
                case "bernoullidisk":
                case "iomegabernoullidisk":
                case "bernoulli disk":
                case "iomega bernoulli disk":
                    return MediaType.IomegaBernoulliDisk;
                case "jaz":
                case "iomegajaz":
                case "iomega jaz":
                    return MediaType.IomegaJaz;
                case "zip":
                case "zipdisk":
                case "iomegazip":
                case "iomega zip":
                    return MediaType.IomegaZip;
                case "ldrom":
                case "lvrom":
                case "ld-rom":
                case "lv-rom":
                case "laserdisc":
                case "laservision":
                case "ld-rom / lv-rom":
                    return MediaType.LaserDisc;
                case "64dd":
                case "n64dd":
                case "64dddisk":
                case "n64dddisk":
                case "64dd disk":
                case "n64dd disk":
                    return MediaType.Nintendo64DD;
                case "fds":
                case "famicom":
                case "nfds":
                case "nintendofamicom":
                case "famicomdisksystem":
                case "famicom disk system":
                case "famicom disk system disk":
                    return MediaType.NintendoFamicomDiskSystem;
                case "gc":
                case "gamecube":
                case "nintendogamecube":
                case "nintendo gamecube":
                case "gamecube disc":
                case "gamecube game disc":
                    return MediaType.NintendoGameCubeGameDisc;
                case "wii":
                case "nintendowii":
                case "nintendo wii":
                case "nintendo wii disc":
                case "wii optical disc":
                    return MediaType.NintendoWiiOpticalDisc;
                case "wiiu":
                case "nintendowiiu":
                case "nintendo wiiu":
                case "nintendo wiiu disc":
                case "wiiu optical disc":
                case "wii u optical disc":
                    return MediaType.NintendoWiiUOpticalDisc;
                case "umd":
                    return MediaType.UMD;

                #endregion

                // Unsorted Formats
                case "cartridge":
                    return MediaType.Cartridge;
                case "ced":
                case "rcaced":
                case "rca ced":
                case "videodisc":
                case "rca videodisc":
                    return MediaType.CED;

                default:
                    return MediaType.NONE;
            }
        }

        #endregion
    }
}