using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MyAudioPostprocessor :  AssetPostprocessor
{
    void OnPreprocessAudio()
    {
        AudioImporter audioImporter = (AudioImporter)assetImporter;
        audioImporter.forceToMono = true;
        audioImporter.loadInBackground = true;
        
        AudioImporterSampleSettings audioImporterSampleSettings = audioImporter.defaultSampleSettings;
        
        var info = new FileInfo(assetPath);
        var length = info.Length;
        var size = length / 1024;

        if (size>=3000)
        {
            audioImporterSampleSettings.loadType = AudioClipLoadType.Streaming;
            Debug.Log(size + " str");
        }
        else if(size>=200)
        {
            audioImporterSampleSettings.loadType = AudioClipLoadType.CompressedInMemory;
            Debug.Log(size+ " comp");
        }
        else
        {
            audioImporterSampleSettings.loadType = AudioClipLoadType.DecompressOnLoad;
            Debug.Log(size+ " decomp");
        }

        audioImporter.SetOverrideSampleSettings("Standalone", audioImporterSampleSettings);
    }
}
