using UniJSON;
using UniJSON;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UniGLTF {

public static class GltfDeserializer
{


public static glTF Deserialize(JsonNode parsed)
{
    var value = new glTF();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("asset"))
            {
            
                value.asset = Deserialize_gltf_asset(kv.Value);
                continue;
            }

            if (key.SequenceEqual("buffers"))
            {
            
                value.buffers = Deserialize_gltf_buffers(kv.Value);
                continue;
            }

            if (key.SequenceEqual("bufferViews"))
            {
            
                value.bufferViews = Deserialize_gltf_bufferViews(kv.Value);
                continue;
            }

            if (key.SequenceEqual("accessors"))
            {
            
                value.accessors = Deserialize_gltf_accessors(kv.Value);
                continue;
            }

            if (key.SequenceEqual("textures"))
            {
            
                value.textures = Deserialize_gltf_textures(kv.Value);
                continue;
            }

            if (key.SequenceEqual("samplers"))
            {
            
                value.samplers = Deserialize_gltf_samplers(kv.Value);
                continue;
            }

            if (key.SequenceEqual("images"))
            {
            
                value.images = Deserialize_gltf_images(kv.Value);
                continue;
            }

            if (key.SequenceEqual("materials"))
            {
            
                value.materials = Deserialize_gltf_materials(kv.Value);
                continue;
            }

            if (key.SequenceEqual("meshes"))
            {
            
                value.meshes = Deserialize_gltf_meshes(kv.Value);
                continue;
            }

            if (key.SequenceEqual("nodes"))
            {
            
                value.nodes = Deserialize_gltf_nodes(kv.Value);
                continue;
            }

            if (key.SequenceEqual("skins"))
            {
            
                value.skins = Deserialize_gltf_skins(kv.Value);
                continue;
            }

            if (key.SequenceEqual("scene"))
            {
            
                value.scene = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("scenes"))
            {
            
                value.scenes = Deserialize_gltf_scenes(kv.Value);
                continue;
            }

            if (key.SequenceEqual("animations"))
            {
            
                value.animations = Deserialize_gltf_animations(kv.Value);
                continue;
            }

            if (key.SequenceEqual("cameras"))
            {
            
                value.cameras = Deserialize_gltf_cameras(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensionsUsed"))
            {
            
                value.extensionsUsed = Deserialize_gltf_extensionsUsed(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensionsRequired"))
            {
            
                value.extensionsRequired = Deserialize_gltf_extensionsRequired(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFAssets Deserialize_gltf_asset(JsonNode parsed)
{
    var value = new glTFAssets();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("generator"))
            {
            
                value.generator = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("version"))
            {
            
                value.version = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("copyright"))
            {
            
                value.copyright = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("minVersion"))
            {
            
                value.minVersion = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFBuffer> Deserialize_gltf_buffers(JsonNode parsed)
{
    var value = new List<glTFBuffer>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_buffers_ITEM(x));
    }
	return value;
}
public static glTFBuffer Deserialize_gltf_buffers_ITEM(JsonNode parsed)
{
    var value = new glTFBuffer();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("uri"))
            {
            
                value.uri = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("byteLength"))
            {
            
                value.byteLength = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFBufferView> Deserialize_gltf_bufferViews(JsonNode parsed)
{
    var value = new List<glTFBufferView>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_bufferViews_ITEM(x));
    }
	return value;
}
public static glTFBufferView Deserialize_gltf_bufferViews_ITEM(JsonNode parsed)
{
    var value = new glTFBufferView();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("buffer"))
            {
            
                value.buffer = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteOffset"))
            {
            
                value.byteOffset = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteLength"))
            {
            
                value.byteLength = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteStride"))
            {
            
                value.byteStride = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("target"))
            {
            
                value.target = (glBufferTarget)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFAccessor> Deserialize_gltf_accessors(JsonNode parsed)
{
    var value = new List<glTFAccessor>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_accessors_ITEM(x));
    }
	return value;
}
public static glTFAccessor Deserialize_gltf_accessors_ITEM(JsonNode parsed)
{
    var value = new glTFAccessor();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("bufferView"))
            {
            
                value.bufferView = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteOffset"))
            {
            
                value.byteOffset = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("type"))
            {
            
                value.type = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("componentType"))
            {
            
                value.componentType = (glComponentType)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("count"))
            {
            
                value.count = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("max"))
            {
            
                value.max = Deserialize_gltf_accessors__max(kv.Value);
                continue;
            }

            if (key.SequenceEqual("min"))
            {
            
                value.min = Deserialize_gltf_accessors__min(kv.Value);
                continue;
            }

            if (key.SequenceEqual("normalized"))
            {
            
                value.normalized = kv.Value.GetBoolean();
                continue;
            }

            if (key.SequenceEqual("sparse"))
            {
            
                value.sparse = Deserialize_gltf_accessors__sparse(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Single[] Deserialize_gltf_accessors__max(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static Single[] Deserialize_gltf_accessors__min(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static glTFSparse Deserialize_gltf_accessors__sparse(JsonNode parsed)
{
    var value = new glTFSparse();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("count"))
            {
            
                value.count = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("indices"))
            {
            
                value.indices = Deserialize_gltf_accessors__sparse_indices(kv.Value);
                continue;
            }

            if (key.SequenceEqual("values"))
            {
            
                value.values = Deserialize_gltf_accessors__sparse_values(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFSparseIndices Deserialize_gltf_accessors__sparse_indices(JsonNode parsed)
{
    var value = new glTFSparseIndices();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("bufferView"))
            {
            
                value.bufferView = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteOffset"))
            {
            
                value.byteOffset = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("componentType"))
            {
            
                value.componentType = (glComponentType)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFSparseValues Deserialize_gltf_accessors__sparse_values(JsonNode parsed)
{
    var value = new glTFSparseValues();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("bufferView"))
            {
            
                value.bufferView = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("byteOffset"))
            {
            
                value.byteOffset = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFTexture> Deserialize_gltf_textures(JsonNode parsed)
{
    var value = new List<glTFTexture>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_textures_ITEM(x));
    }
	return value;
}
public static glTFTexture Deserialize_gltf_textures_ITEM(JsonNode parsed)
{
    var value = new glTFTexture();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("sampler"))
            {
            
                value.sampler = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("source"))
            {
            
                value.source = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFTextureSampler> Deserialize_gltf_samplers(JsonNode parsed)
{
    var value = new List<glTFTextureSampler>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_samplers_ITEM(x));
    }
	return value;
}
public static glTFTextureSampler Deserialize_gltf_samplers_ITEM(JsonNode parsed)
{
    var value = new glTFTextureSampler();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("magFilter"))
            {
            
                value.magFilter = (glFilter)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("minFilter"))
            {
            
                value.minFilter = (glFilter)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("wrapS"))
            {
            
                value.wrapS = (glWrap)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("wrapT"))
            {
            
                value.wrapT = (glWrap)kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFImage> Deserialize_gltf_images(JsonNode parsed)
{
    var value = new List<glTFImage>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_images_ITEM(x));
    }
	return value;
}
public static glTFImage Deserialize_gltf_images_ITEM(JsonNode parsed)
{
    var value = new glTFImage();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("uri"))
            {
            
                value.uri = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("bufferView"))
            {
            
                value.bufferView = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("mimeType"))
            {
            
                value.mimeType = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFMaterial> Deserialize_gltf_materials(JsonNode parsed)
{
    var value = new List<glTFMaterial>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_materials_ITEM(x));
    }
	return value;
}
public static glTFMaterial Deserialize_gltf_materials_ITEM(JsonNode parsed)
{
    var value = new glTFMaterial();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("pbrMetallicRoughness"))
            {
            
                value.pbrMetallicRoughness = Deserialize_gltf_materials__pbrMetallicRoughness(kv.Value);
                continue;
            }

            if (key.SequenceEqual("normalTexture"))
            {
            
                value.normalTexture = Deserialize_gltf_materials__normalTexture(kv.Value);
                continue;
            }

            if (key.SequenceEqual("occlusionTexture"))
            {
            
                value.occlusionTexture = Deserialize_gltf_materials__occlusionTexture(kv.Value);
                continue;
            }

            if (key.SequenceEqual("emissiveTexture"))
            {
            
                value.emissiveTexture = Deserialize_gltf_materials__emissiveTexture(kv.Value);
                continue;
            }

            if (key.SequenceEqual("emissiveFactor"))
            {
            
                value.emissiveFactor = Deserialize_gltf_materials__emissiveFactor(kv.Value);
                continue;
            }

            if (key.SequenceEqual("alphaMode"))
            {
            
                value.alphaMode = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("alphaCutoff"))
            {
            
                value.alphaCutoff = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("doubleSided"))
            {
            
                value.doubleSided = kv.Value.GetBoolean();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFPbrMetallicRoughness Deserialize_gltf_materials__pbrMetallicRoughness(JsonNode parsed)
{
    var value = new glTFPbrMetallicRoughness();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("baseColorTexture"))
            {
            
                value.baseColorTexture = Deserialize_gltf_materials__pbrMetallicRoughness_baseColorTexture(kv.Value);
                continue;
            }

            if (key.SequenceEqual("baseColorFactor"))
            {
            
                value.baseColorFactor = Deserialize_gltf_materials__pbrMetallicRoughness_baseColorFactor(kv.Value);
                continue;
            }

            if (key.SequenceEqual("metallicRoughnessTexture"))
            {
            
                value.metallicRoughnessTexture = Deserialize_gltf_materials__pbrMetallicRoughness_metallicRoughnessTexture(kv.Value);
                continue;
            }

            if (key.SequenceEqual("metallicFactor"))
            {
            
                value.metallicFactor = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("roughnessFactor"))
            {
            
                value.roughnessFactor = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFMaterialBaseColorTextureInfo Deserialize_gltf_materials__pbrMetallicRoughness_baseColorTexture(JsonNode parsed)
{
    var value = new glTFMaterialBaseColorTextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("index"))
            {
            
                value.index = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("texCoord"))
            {
            
                value.texCoord = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Single[] Deserialize_gltf_materials__pbrMetallicRoughness_baseColorFactor(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static glTFMaterialMetallicRoughnessTextureInfo Deserialize_gltf_materials__pbrMetallicRoughness_metallicRoughnessTexture(JsonNode parsed)
{
    var value = new glTFMaterialMetallicRoughnessTextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("index"))
            {
            
                value.index = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("texCoord"))
            {
            
                value.texCoord = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFMaterialNormalTextureInfo Deserialize_gltf_materials__normalTexture(JsonNode parsed)
{
    var value = new glTFMaterialNormalTextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("scale"))
            {
            
                value.scale = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("index"))
            {
            
                value.index = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("texCoord"))
            {
            
                value.texCoord = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFMaterialOcclusionTextureInfo Deserialize_gltf_materials__occlusionTexture(JsonNode parsed)
{
    var value = new glTFMaterialOcclusionTextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("strength"))
            {
            
                value.strength = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("index"))
            {
            
                value.index = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("texCoord"))
            {
            
                value.texCoord = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFMaterialEmissiveTextureInfo Deserialize_gltf_materials__emissiveTexture(JsonNode parsed)
{
    var value = new glTFMaterialEmissiveTextureInfo();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("index"))
            {
            
                value.index = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("texCoord"))
            {
            
                value.texCoord = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Single[] Deserialize_gltf_materials__emissiveFactor(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static List<UniGLTF.glTFMesh> Deserialize_gltf_meshes(JsonNode parsed)
{
    var value = new List<glTFMesh>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_meshes_ITEM(x));
    }
	return value;
}
public static glTFMesh Deserialize_gltf_meshes_ITEM(JsonNode parsed)
{
    var value = new glTFMesh();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("primitives"))
            {
            
                value.primitives = Deserialize_gltf_meshes__primitives(kv.Value);
                continue;
            }

            if (key.SequenceEqual("weights"))
            {
            
                value.weights = Deserialize_gltf_meshes__weights(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFPrimitives> Deserialize_gltf_meshes__primitives(JsonNode parsed)
{
    var value = new List<glTFPrimitives>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_meshes__primitives_ITEM(x));
    }
	return value;
}
public static glTFPrimitives Deserialize_gltf_meshes__primitives_ITEM(JsonNode parsed)
{
    var value = new glTFPrimitives();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("mode"))
            {
            
                value.mode = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("indices"))
            {
            
                value.indices = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("attributes"))
            {
            
                value.attributes = Deserialize_gltf_meshes__primitives__attributes(kv.Value);
                continue;
            }

            if (key.SequenceEqual("material"))
            {
            
                value.material = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("targets"))
            {
            
                value.targets = Deserialize_gltf_meshes__primitives__targets(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFAttributes Deserialize_gltf_meshes__primitives__attributes(JsonNode parsed)
{
    var value = new glTFAttributes();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("POSITION"))
            {
            
                value.POSITION = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("NORMAL"))
            {
            
                value.NORMAL = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("TANGENT"))
            {
            
                value.TANGENT = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("TEXCOORD_0"))
            {
            
                value.TEXCOORD_0 = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("TEXCOORD_1"))
            {
            
                value.TEXCOORD_1 = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("COLOR_0"))
            {
            
                value.COLOR_0 = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("JOINTS_0"))
            {
            
                value.JOINTS_0 = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("WEIGHTS_0"))
            {
            
                value.WEIGHTS_0 = kv.Value.GetInt32();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.gltfMorphTarget> Deserialize_gltf_meshes__primitives__targets(JsonNode parsed)
{
    var value = new List<gltfMorphTarget>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_meshes__primitives__targets_ITEM(x));
    }
	return value;
}
public static gltfMorphTarget Deserialize_gltf_meshes__primitives__targets_ITEM(JsonNode parsed)
{
    var value = new gltfMorphTarget();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("POSITION"))
            {
            
                value.POSITION = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("NORMAL"))
            {
            
                value.NORMAL = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("TANGENT"))
            {
            
                value.TANGENT = kv.Value.GetInt32();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Single[] Deserialize_gltf_meshes__weights(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static List<UniGLTF.glTFNode> Deserialize_gltf_nodes(JsonNode parsed)
{
    var value = new List<glTFNode>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_nodes_ITEM(x));
    }
	return value;
}
public static glTFNode Deserialize_gltf_nodes_ITEM(JsonNode parsed)
{
    var value = new glTFNode();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("children"))
            {
            
                value.children = Deserialize_gltf_nodes__children(kv.Value);
                continue;
            }

            if (key.SequenceEqual("matrix"))
            {
            
                value.matrix = Deserialize_gltf_nodes__matrix(kv.Value);
                continue;
            }

            if (key.SequenceEqual("translation"))
            {
            
                value.translation = Deserialize_gltf_nodes__translation(kv.Value);
                continue;
            }

            if (key.SequenceEqual("rotation"))
            {
            
                value.rotation = Deserialize_gltf_nodes__rotation(kv.Value);
                continue;
            }

            if (key.SequenceEqual("scale"))
            {
            
                value.scale = Deserialize_gltf_nodes__scale(kv.Value);
                continue;
            }

            if (key.SequenceEqual("mesh"))
            {
            
                value.mesh = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("skin"))
            {
            
                value.skin = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("weights"))
            {
            
                value.weights = Deserialize_gltf_nodes__weights(kv.Value);
                continue;
            }

            if (key.SequenceEqual("camera"))
            {
            
                value.camera = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Int32[] Deserialize_gltf_nodes__children(JsonNode parsed)
{
    var value = new Int32[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetInt32();
    }
	return value;
} 

public static Single[] Deserialize_gltf_nodes__matrix(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static Single[] Deserialize_gltf_nodes__translation(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static Single[] Deserialize_gltf_nodes__rotation(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static Single[] Deserialize_gltf_nodes__scale(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static Single[] Deserialize_gltf_nodes__weights(JsonNode parsed)
{
    var value = new Single[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetSingle();
    }
	return value;
} 

public static List<UniGLTF.glTFSkin> Deserialize_gltf_skins(JsonNode parsed)
{
    var value = new List<glTFSkin>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_skins_ITEM(x));
    }
	return value;
}
public static glTFSkin Deserialize_gltf_skins_ITEM(JsonNode parsed)
{
    var value = new glTFSkin();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("inverseBindMatrices"))
            {
            
                value.inverseBindMatrices = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("joints"))
            {
            
                value.joints = Deserialize_gltf_skins__joints(kv.Value);
                continue;
            }

            if (key.SequenceEqual("skeleton"))
            {
            
                value.skeleton = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Int32[] Deserialize_gltf_skins__joints(JsonNode parsed)
{
    var value = new Int32[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetInt32();
    }
	return value;
} 

public static List<UniGLTF.gltfScene> Deserialize_gltf_scenes(JsonNode parsed)
{
    var value = new List<gltfScene>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_scenes_ITEM(x));
    }
	return value;
}
public static gltfScene Deserialize_gltf_scenes_ITEM(JsonNode parsed)
{
    var value = new gltfScene();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("nodes"))
            {
            
                value.nodes = Deserialize_gltf_scenes__nodes(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static Int32[] Deserialize_gltf_scenes__nodes(JsonNode parsed)
{
    var value = new Int32[parsed.GetArrayCount()];
    int i=0;
    foreach(var x in parsed.ArrayItems())
    {
        value[i++] = x.GetInt32();
    }
	return value;
} 

public static List<UniGLTF.glTFAnimation> Deserialize_gltf_animations(JsonNode parsed)
{
    var value = new List<glTFAnimation>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_animations_ITEM(x));
    }
	return value;
}
public static glTFAnimation Deserialize_gltf_animations_ITEM(JsonNode parsed)
{
    var value = new glTFAnimation();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("channels"))
            {
            
                value.channels = Deserialize_gltf_animations__channels(kv.Value);
                continue;
            }

            if (key.SequenceEqual("samplers"))
            {
            
                value.samplers = Deserialize_gltf_animations__samplers(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFAnimationChannel> Deserialize_gltf_animations__channels(JsonNode parsed)
{
    var value = new List<glTFAnimationChannel>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_animations__channels_ITEM(x));
    }
	return value;
}
public static glTFAnimationChannel Deserialize_gltf_animations__channels_ITEM(JsonNode parsed)
{
    var value = new glTFAnimationChannel();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("sampler"))
            {
            
                value.sampler = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("target"))
            {
            
                value.target = Deserialize_gltf_animations__channels__target(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFAnimationTarget Deserialize_gltf_animations__channels__target(JsonNode parsed)
{
    var value = new glTFAnimationTarget();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("node"))
            {
            
                value.node = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("path"))
            {
            
                value.path = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFAnimationSampler> Deserialize_gltf_animations__samplers(JsonNode parsed)
{
    var value = new List<glTFAnimationSampler>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_animations__samplers_ITEM(x));
    }
	return value;
}
public static glTFAnimationSampler Deserialize_gltf_animations__samplers_ITEM(JsonNode parsed)
{
    var value = new glTFAnimationSampler();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("input"))
            {
            
                value.input = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("interpolation"))
            {
            
                value.interpolation = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("output"))
            {
            
                value.output = kv.Value.GetInt32();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<UniGLTF.glTFCamera> Deserialize_gltf_cameras(JsonNode parsed)
{
    var value = new List<glTFCamera>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(Deserialize_gltf_cameras_ITEM(x));
    }
	return value;
}
public static glTFCamera Deserialize_gltf_cameras_ITEM(JsonNode parsed)
{
    var value = new glTFCamera();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("orthographic"))
            {
            
                value.orthographic = Deserialize_gltf_cameras__orthographic(kv.Value);
                continue;
            }

            if (key.SequenceEqual("perspective"))
            {
            
                value.perspective = Deserialize_gltf_cameras__perspective(kv.Value);
                continue;
            }

            if (key.SequenceEqual("type"))
            {
            
                value.type = (ProjectionType)Enum.Parse(typeof(ProjectionType), kv.Value.GetString(), true);
                continue;
            }

            if (key.SequenceEqual("name"))
            {
            
                value.name = kv.Value.GetString();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFOrthographic Deserialize_gltf_cameras__orthographic(JsonNode parsed)
{
    var value = new glTFOrthographic();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("xmag"))
            {
            
                value.xmag = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("ymag"))
            {
            
                value.ymag = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("zfar"))
            {
            
                value.zfar = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("znear"))
            {
            
                value.znear = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static glTFPerspective Deserialize_gltf_cameras__perspective(JsonNode parsed)
{
    var value = new glTFPerspective();

    foreach(var kv in parsed.ObjectItems())
    {
        var utf8Key =kv.Key.GetUtf8String();
        char[] rentArray = ArrayPool<char>.Shared.Rent(utf8Key.ByteLength);
        try
        {
            var key = rentArray.AsSpan();
            var count = Utf8String.Encoding.GetChars(utf8Key.AsSpan(), key);
            key = key[..count];

            if (key.SequenceEqual("aspectRatio"))
            {
            
                value.aspectRatio = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("yfov"))
            {
            
                value.yfov = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("zfar"))
            {
            
                value.zfar = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("znear"))
            {
            
                value.znear = kv.Value.GetSingle();
                continue;
            }

            if (key.SequenceEqual("extensions"))
            {
            
                value.extensions = new glTFExtensionImport(kv.Value);
                continue;
            }

            if (key.SequenceEqual("extras"))
            {
            
                value.extras = new glTFExtensionImport(kv.Value);
                continue;
            }

        }
        finally
        {
            ArrayPool<char>.Shared.Return(rentArray);
        }
    }
    return value;
}

public static List<System.String> Deserialize_gltf_extensionsUsed(JsonNode parsed)
{
    var value = new List<String>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(x.GetString());
    }
	return value;
}
public static List<System.String> Deserialize_gltf_extensionsRequired(JsonNode parsed)
{
    var value = new List<String>(parsed.GetArrayCount());
    foreach(var x in parsed.ArrayItems())
    {
        value.Add(x.GetString());
    }
	return value;
}
} // GltfDeserializer
} // UniGLTF 
