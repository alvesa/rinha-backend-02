FROM node:20-alpine AS build
WORKDIR /app
COPY ./package*.json ./
RUN npm install
COPY ./ ./
RUN npm run build

# FROM node:20-alpine AS runtime
# WORKDIR /app
# COPY --from=build /app/dist ./dist
# COPY --from=build /app/package*.json ./
# RUN npm ci --only=production
CMD ["npm", "run", "start:prod"]
