#stage 1 - build project
FROM node:10.16.0-alpine as react-build
COPY . /app
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
RUN npm install --silent
RUN npm run build

# Stage 2 - the production environment
FROM nginx:latest
LABEL Author="Rubens Carriel" 
COPY ./config/nginx.conf /etc/nginx/nginx.conf
COPY --from=react-build /app/dist /var/www/public

EXPOSE 80 433

ENTRYPOINT [ "nginx" ]
CMD [ "-g", "daemon off;" ]