## Description

Samples a **Texture 2D Array** and returns a **Vector 4** color value for use in the shader. You can override the **UV** coordinates using the **UV** input and define a custom **Sampler State** using the **Sampler** input. Use the **Index** input to specify which index of the array to sample.


## Ports

| Name        | Direction           | Type  | Binding | Description |
|:------------ |:-------------|:-----|:---|:---|
| Texture Array |	Input |	Texture 2D Array  | None | Texture 2D Array to sample |
| Index   | Input |	Vector 1    | None	| Index of array to sample |
| UV      | Input |	Vector 2    | 	UV	| Mesh's normal vector |
| Sampler | Input |	Sampler State | Default sampler state | Sampler for the texture |
| RGBA	| Output	| Vector 4	| None	| Output value as RGBA |
| R	    | Output	| Vector 1	| None	| red (x) component of RGBA output |
| G	    | Output	| Vector 1	| None	| green (y) component of RGBA output |
| B	    | Output	| Vector 1	| None	| blue (z) component of RGBA output |
| A     |	Output	| Vector 1	| None | alpha (w) component of RGBA output |