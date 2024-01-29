#version 330 core
layout (location = 0) in vec3 aPosition; //position variable has attribute position 0
layout (location = 1) in vec2 vertexUVCoord;

uniform mat4 projection;
uniform mat4 transformation;
uniform int useTexture;

out vec2 textureCoord;

void main()
{
gl_Position = vec4(aPosition, 1.0f) * transformation * projection;
if (useTexture != 0)
{
	textureCoord = vertexUVCoord;
	}
}