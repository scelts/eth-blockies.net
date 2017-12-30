# ETH_Blockies.net

![Sample blockies image](sample.png "Blockies")

.net (c#) port to generate identicons from the ethereum address, like the ones used in Mist or etherscan or similar...
1:1 copy of the "official" implementation [https://github.com/ethereum/blockies](https://github.com/ethereum/blockies), written in c#


### Example usage

```
using ETH_Identicons;
...
Identicon identicon = new Identicon("0x942766be6F3171A4D5c0257a3869233b501175e1", 8); //generates identicon as in Mist (8x8) for the address
identicon.GetBitmap(64); //generates 64x64 Bitmap of the identicon (best to use multiples of 8)
identicon.GetIcon(64); //generates 64x64 Icon of the identicon (best to use multiples of 8)
```

Or just look at the ExampleApp included with the Solution...

### Licence

[Same as the original](http://www.wtfpl.net/)



