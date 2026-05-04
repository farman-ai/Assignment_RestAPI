# LenceCart AI Commerce OS

This project is a front-end prototype for an AI-powered ecommerce experience platform.

It demonstrates:

- Real-time clothing try-on style presentation
- AI shopping guidance for different customer personas
- Offline-first commerce flows for low-network environments
- 3D-ready product storytelling for fashion and lifestyle brands
- Smart cart and sync messaging for omnichannel commerce

## Files

- `index.html` contains the product landing page and interactive demo layout
- `styles.css` contains the visual system, responsive layout, and product scene animations
- `app.js` powers the live demo state, product switching, persona logic, and sync simulation

## Run

Run:

```bash
node server.js
```

Then open `http://localhost:8000`.

## Notes

This now includes:

- manual photo dressing studio
- camera overlay preview
- a real AI try-on proxy for Replicate IDM-VTON

For AI generation you need a Replicate API token. The app sends:

- person photo
- garment photo
- garment category
- garment description

to the IDM-VTON model through the local `/api/tryon` proxy.

The current model path uses Replicate IDM-VTON and is intended for non-commercial use only according to the model license.

The next step would be improving automatic placement and garment/background cleanup.

- a product catalog API
- shopper profile and recommendation services
- 3D model delivery
- camera-based AR try-on
- offline storage and sync infrastructure
# Assignment_RestAPI
