#stage 1 - build project
FROM node:10.16.0-alpine as react-build
COPY . /app
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
RUN npm install --silent
RUN npm start --silent

# Stage 2 - the production environment
FROM nginx:alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=react-build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]