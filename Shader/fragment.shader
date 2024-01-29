#version 330 core

uniform vec3 color;
uniform sampler2D textureUnit;
uniform int useTexture;

out vec4 fragColor;
in vec2 textureCoord;

void main()
{
	if (useTexture != 0)
	{
		fragColor = texture(textureUnit, textureCoord);
    }
		else {
fragColor = vec4(color, 1.0);
}
}