FROM nginx:1.17.1-alpine AS base

FROM node:12.7-alpine AS build
WORKDIR /app
COPY web/frontend/angular/nemstore-orders/ .
RUN npm install
RUN npm run build

FROM base AS final
COPY --from=build /app/dist/nemstore-orders /usr/share/nginx/html
