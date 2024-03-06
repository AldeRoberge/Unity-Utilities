using UnityEditor;
using UnityEngine;

namespace AGES.Utils.Editor
{
    public static class FlipSprites
    {
        private enum Direction
        {
            Horizontal,
            Vertical,
            HorizontalAndVertical
        }

        [MenuItem("Edit/Flip Sprite Horizontally (Left to Right)")]
        static void FlipSelectedSpritesHorizontally()
        {
            FlipSelectedSprites(Direction.Horizontal);
        }

        [MenuItem("Edit/Flip Sprite Vertically (Top to Bottom)")]
        static void FlipSelectedSpritesVertically()
        {
            FlipSelectedSprites(Direction.Vertical);
        }

        [MenuItem("Edit/Flip Sprite Horizontally and Vertically (90 degrees)")]
        static void FlipSelectedSpritesHorizontallyAndVertically()
        {
            FlipSelectedSprites(Direction.HorizontalAndVertical);
        }

        private static void FlipSelectedSprites(Direction direction)
        {
            // Get the selected sprites in the project window
            var sprites = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);

            if (sprites.Length == 0)
            {
                Debug.Log("No sprites selected");
                return;
            }

            Debug.Log($"Flipping {sprites.Length} sprites.");

            // Loop through the selected sprites
            foreach (Texture2D sprite in sprites)
            {
                // Get the path of the sprite asset
                var path = AssetDatabase.GetAssetPath(sprite);

                // Load the texture of the sprite
                var textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;

                if (textureImporter != null && !textureImporter.isReadable)
                {
                    textureImporter.isReadable = true;
                    AssetDatabase.ImportAsset(path);
                }

                var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);


                var pixels = texture.GetPixels();

                if (direction is Direction.Horizontal or Direction.HorizontalAndVertical)
                {
                    for (var i = 0; i < pixels.Length; i++)
                    {
                        var x = i % texture.width;
                        var y = i / texture.width;
                        pixels[i] = texture.GetPixel(texture.width - x - 1, y);
                    }
                }

                if (direction is Direction.Vertical or Direction.HorizontalAndVertical)
                {
                    for (var i = 0; i < pixels.Length; i++)
                    {
                        var x = i % texture.width;
                        var y = i / texture.width;
                        pixels[i] = texture.GetPixel(x, texture.height - y - 1);
                    }
                }

                texture.SetPixels(pixels);
                texture.Apply();

                var bytes = texture.EncodeToPNG();
                System.IO.File.WriteAllBytes(path, bytes);

                // Save the changes
                AssetDatabase.ImportAsset(path);
                AssetDatabase.Refresh();
            }
        }
    }
}