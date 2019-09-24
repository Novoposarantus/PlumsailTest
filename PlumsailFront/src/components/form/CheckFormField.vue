<template>
    <div>
        <label class="form-title">{{label}}</label>
        <span class="form-error-text">{{error}}</span>
        <div>
            <slot />
        </div>
    </div>
</template>

<script>
export default {
    props: {
        label: {
            type: String,
            required: true
        },
        error: String,
    },
}
</script>